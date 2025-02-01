using DevIO.Data.Context;
using DevIO.Domain.Interfaces;
using DevIO.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(ApiTresCamadasDbContext dbContext) : base(dbContext)
        {
        }
       
        public async Task<Fornecedor?> ObterFornecedorEndereco(Guid id)
        {
            return await _dbContext.Fornecedores.AsNoTracking()
                .Include(x => x.Endereco)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Fornecedor?> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await _dbContext.Fornecedores.AsNoTracking()
                .Include(x => x.Produtos)
                .Include(x => x.Endereco)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Endereco?> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await _dbContext.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(x => x.FornecedorId == fornecedorId);
        }

        public async Task RemoverEnderecoFornecedor(Endereco endereco)
        {
            _dbContext.Enderecos.Remove(endereco);
            await SaveChanges();
        }
    }
}
