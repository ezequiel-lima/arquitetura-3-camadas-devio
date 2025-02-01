using DevIO.Data.Context;
using DevIO.Domain.Interfaces;
using DevIO.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApiTresCamadasDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Produto?> ObterProdutoFornecedor(Guid id)
        {
            return await _dbContext.Produtos.AsNoTracking()
                .Include(x => x.Fornecedor)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await _dbContext.Produtos.AsNoTracking()
                .Include(x => x.Fornecedor)
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(x => x.FornecedorId == fornecedorId);
        }
    }
}
