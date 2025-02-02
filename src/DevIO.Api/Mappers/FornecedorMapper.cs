using DevIO.Api.ViewModels;
using DevIO.Domain.Mappers;
using DevIO.Domain.Models;

namespace DevIO.Api.Mappers
{
    public static class FornecedorMapper
    {
        public static Fornecedor MapearParaEntidade(this FornecedorViewModel viewModel)
        {
            return new Fornecedor
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Documento = viewModel.Documento,
                TipoFornecedor = (ETipoFornecedor)viewModel.TipoFornecedor, 
                Ativo = viewModel.Ativo,
                Endereco = viewModel.Endereco?.MapearParaEntidade(),
                Produtos = viewModel.Produtos?.Select(x => x.MapearParaEntidade()).ToList() ?? new List<Produto>() 
            };
        }

        public static FornecedorViewModel MapearParaViewModel(this Fornecedor entity)
        {
            return new FornecedorViewModel
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Documento = entity.Documento,
                TipoFornecedor = (int)entity.TipoFornecedor,
                Ativo = entity.Ativo,
                Endereco = entity.Endereco?.MapearParaViewModel(),
                Produtos = entity.Produtos?.Select(p => p.MapearParaViewModel()).ToList() ?? new List<ProdutoViewModel>() 
            };
        }
    }
}
