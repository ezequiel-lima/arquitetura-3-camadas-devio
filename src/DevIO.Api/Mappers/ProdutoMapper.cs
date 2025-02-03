using DevIO.Api.ViewModels;
using DevIO.Domain.Models;

namespace DevIO.Domain.Mappers
{
    public static class ProdutoMapper
    {
        public static Produto MapearParaEntidade(this ProdutoViewModel viewModel)
        {
            return new Produto
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Descricao = viewModel.Descricao,
                Valor = viewModel.Valor,
                DataCadastro = viewModel.DataCadastro,
                Ativo = viewModel.Ativo,
                FornecedorId = viewModel.FornecedorId
            };
        }

        public static ProdutoViewModel MapearParaViewModel(this Produto entity)
        {
            return new ProdutoViewModel
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Descricao = entity.Descricao,
                Valor = entity.Valor,
                DataCadastro = entity.DataCadastro,
                Ativo = entity.Ativo,
                FornecedorId = entity.FornecedorId,
                NomeFornecedor = entity.Fornecedor.Nome
            };
        }

        public static IEnumerable<ProdutoViewModel> MapearParaViewModel(IEnumerable<Produto> produtos)
        {
            return produtos.Select(MapearParaViewModel);
        }
    }
}
