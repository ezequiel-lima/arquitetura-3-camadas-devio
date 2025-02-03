using DevIO.Domain.Models;

namespace DevIO.Domain.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto?> ObterPorId(Guid id);
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
