using DevIO.Api.ViewModels;
using DevIO.Domain.Models;

namespace DevIO.Api.Mappers
{
    public static class EnderecoMapper
    {
        public static Endereco MapearParaEntidade(this EnderecoViewModel viewModel)
        {
            return new Endereco
            {
                Id = viewModel.Id,
                Logradouro = viewModel.Logradouro,
                Numero = viewModel.Numero,
                Complemento = viewModel.Complemento,
                Bairro = viewModel.Bairro,
                Cep = viewModel.Cep,
                Cidade = viewModel.Cidade,
                Estado = viewModel.Estado,
                FornecedorId = viewModel.FornecedorId
            };
        }

        public static EnderecoViewModel MapearParaViewModel(this Endereco entity)
        {
            return new EnderecoViewModel
            {
                Id = entity.Id,
                Logradouro = entity.Logradouro,
                Numero = entity.Numero,
                Complemento = entity.Complemento,
                Bairro = entity.Bairro,
                Cep = entity.Cep,
                Cidade = entity.Cidade,
                Estado = entity.Estado,
                FornecedorId = entity.FornecedorId
            };
        }
    }
}
