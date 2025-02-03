using DevIO.Domain.Interfaces;
using DevIO.Domain.Models;
using DevIO.Domain.Models.Validations;

namespace DevIO.Domain.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _produtoRepository.ObterProdutosFornecedores();
        }

        public async Task<Produto?> ObterPorId(Guid id)
        {
            return await _produtoRepository.ObterProdutoFornecedor(id);
        }

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto))
                return;

            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            var produtoParaAtualizacao = await _produtoRepository.ObterPorId(produto.Id);
            if (produtoParaAtualizacao is null)
            {
                Notificar("Produto não encontrado!");
                return;
            }

            produtoParaAtualizacao.Nome = produto.Nome;
            produtoParaAtualizacao.Descricao = produto.Descricao;
            produtoParaAtualizacao.Valor = produto.Valor;
            produtoParaAtualizacao.Ativo = produto.Ativo;

            if (!ExecutarValidacao(new ProdutoValidation(), produtoParaAtualizacao))
                return;

            await _produtoRepository.Atualizar(produtoParaAtualizacao);
        }

        public async Task Remover(Guid id)
        {
            var produto = await _produtoRepository.ObterPorId(id);

            if (produto is null)
            {
                Notificar("Produto não encontrado!");
                return;
            }

            await _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
