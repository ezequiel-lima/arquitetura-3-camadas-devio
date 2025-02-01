using DevIO.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Context
{
    public class ApiTresCamadasDbContext : DbContext
    {
        public ApiTresCamadasDbContext(DbContextOptions<ApiTresCamadasDbContext> options) : base(options) 
        {
            // Desativa o rastreamento de entidades (NoTracking) e a detecção automática de alterações.
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define um tamanho padrão para colunas do tipo string que não tenham o tamanho especificado explicitamente.
            // Neste caso, as propriedades string serão configuradas como "varchar(200)".
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties()
                .Where(y => y.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(200)");
            }           

            // Essa configuração permite que, ao executar uma migration, todas as classes que implementam a interface
            // IEntityTypeConfiguration sejam automaticamente aplicadas. 
            // Assim, não é necessário registrar manualmente cada novo mapeamento no contexto.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiTresCamadasDbContext).Assembly);

            // Configura o comportamento de exclusão para todas as chaves estrangeiras do modelo, definindo como ClientSetNull.
            // Por exemplo, ao excluir um fornecedor, os produtos relacionados não serão excluídos automaticamente,
            // Prevenindo a exclusão em cascata.
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Ao salvar no banco de dados, este método garante que:
            // - Quando um novo registro for adicionado, a propriedade "DataCadastro" será preenchida automaticamente com a data atual.
            // - Quando um registro existente for modificado, a propriedade "DataCadastro" não será alterada, preservando o valor original.
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
