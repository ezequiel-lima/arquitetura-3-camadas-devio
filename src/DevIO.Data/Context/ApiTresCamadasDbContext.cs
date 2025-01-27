using DevIO.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Context
{
    public class ApiTresCamadasDbContext : DbContext
    {
        public ApiTresCamadasDbContext(DbContextOptions<ApiTresCamadasDbContext> options) : base(options) 
        {

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
    }
}
