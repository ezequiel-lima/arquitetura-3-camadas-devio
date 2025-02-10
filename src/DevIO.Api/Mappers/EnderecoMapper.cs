using DevIO.Api.Dto.Requests;
using DevIO.Api.Dto.Responses;
using DevIO.Domain.Models;

namespace DevIO.Api.Mappers
{
    public static class EnderecoMapper
    {
        public static Endereco MapearParaEntidade(this CreateEnderecoRequest createEnderecoRequest)
        {
            return new Endereco
            {
                Logradouro = createEnderecoRequest.Logradouro,
                Numero = createEnderecoRequest.Numero,
                Complemento = createEnderecoRequest.Complemento,
                Bairro = createEnderecoRequest.Bairro,
                Cep = createEnderecoRequest.Cep,
                Cidade = createEnderecoRequest.Cidade,
                Estado = createEnderecoRequest.Estado
            };
        }

        public static EnderecoResponse MapearParaResponse(this Endereco entity)
        {
            return new EnderecoResponse
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
