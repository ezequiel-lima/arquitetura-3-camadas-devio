using DevIO.Domain.Models;

namespace DevIO.Domain.Interfaces
{
    public interface IFornecedorService : IDisposable
    {
        Task<Fornecedor?> ObterPorId(Guid id);
        Task<IEnumerable<Fornecedor>> ObterTodos();
        Task Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
        Task Remover(Guid id);
    }
}
