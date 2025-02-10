using DevIO.Api.Dto.Requests;
using DevIO.Api.Dto.Responses;
using DevIO.Domain.Models;

namespace DevIO.Domain.Mappers
{
    public static class ProdutoMapper
    {
        public static Produto MapearParaEntidade(this CreateProdutoRequest createProdutoRequest)
        {
            return new Produto
            {
                Nome = createProdutoRequest.Nome,
                Descricao = createProdutoRequest.Descricao,
                Valor = createProdutoRequest.Valor,
                DataCadastro = createProdutoRequest.DataCadastro,
                Ativo = createProdutoRequest.Ativo,
                FornecedorId = createProdutoRequest.FornecedorId
            };
        }

        public static Produto MapearParaEntidade(this UpdateProdutoRequest updateProdutoRequest)
        {
            return new Produto
            {
                Id = updateProdutoRequest.Id,
                Nome = updateProdutoRequest.Nome,
                Descricao = updateProdutoRequest.Descricao,
                Valor = updateProdutoRequest.Valor,
                DataCadastro = updateProdutoRequest.DataCadastro,
                Ativo = updateProdutoRequest.Ativo,
                FornecedorId = updateProdutoRequest.FornecedorId
            };
        }

        public static ProdutoResponse MapearParaResponse(this Produto produto)
        {
            return new ProdutoResponse
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Valor = produto.Valor,
                DataCadastro = produto.DataCadastro,
                Ativo = produto.Ativo,
                FornecedorId = produto.FornecedorId,
                NomeFornecedor = produto.Fornecedor.Nome
            };
        }

        public static CreateProdutoResponse MapearParaCreateResponse(this Produto produto)
        {
            return new CreateProdutoResponse
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Valor = produto.Valor,
                DataCadastro = produto.DataCadastro,
                Ativo = produto.Ativo,
                FornecedorId = produto.FornecedorId
            };
        }

        public static IEnumerable<ProdutoResponse> MapearParaResponse(IEnumerable<Produto> produtos)
        {
            return produtos.Select(MapearParaResponse);
        }
    }
}
