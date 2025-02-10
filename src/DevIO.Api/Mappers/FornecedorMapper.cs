using DevIO.Api.Dto.Requests;
using DevIO.Api.Dto.Responses;
using DevIO.Domain.Mappers;
using DevIO.Domain.Models;

namespace DevIO.Api.Mappers
{
    public static class FornecedorMapper
    {
        public static Fornecedor MapearParaEntidade(this CreateFornecedorRequest fornecedor)
        {
            return new Fornecedor
            {
                Nome = fornecedor.Nome,
                Documento = fornecedor.Documento,
                TipoFornecedor = (ETipoFornecedor)fornecedor.TipoFornecedor,
                Ativo = fornecedor.Ativo,
                Endereco = fornecedor.Endereco.MapearParaEntidade()
            };
        }

        public static FornecedorResponse MapearParaResponse(this Fornecedor fornecedor)
        {
            return new FornecedorResponse
            {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                Documento = fornecedor.Documento,
                TipoFornecedor = (int)fornecedor.TipoFornecedor,
                Ativo = fornecedor.Ativo
            };
        }

        public static DetailsFornecedorResponse MapearParaDetailsResponse(this Fornecedor fornecedor)
        {
            return new DetailsFornecedorResponse
            {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                Documento = fornecedor.Documento,
                TipoFornecedor = (int)fornecedor.TipoFornecedor,
                Ativo = fornecedor.Ativo,
                Endereco = fornecedor.Endereco?.MapearParaResponse(),
                Produtos = fornecedor.Produtos?.Select(x => x.MapearParaResponse()).ToList() ?? new List<ProdutoResponse>()
            };
        }

        public static IEnumerable<FornecedorResponse> MapearParaResponse(IEnumerable<Fornecedor> fornecedores)
        {
            return fornecedores.Select(MapearParaResponse);
        }
    }
}
