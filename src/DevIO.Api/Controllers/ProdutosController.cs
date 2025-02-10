using DevIO.Api.Dto.Requests;
using DevIO.Api.Dto.Responses;
using DevIO.Domain.Interfaces;
using DevIO.Domain.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DevIO.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService, INotificador notificador) : base(notificador)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoResponse>>> ObterTodos()
        {
            var produtos = await _produtoService.ObterTodos();
            var response = ProdutoMapper.MapearParaResponse(produtos);
            return CustomResponse(HttpStatusCode.OK, response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoResponse>> ObterPorId(Guid id)
        {
            var produto = await _produtoService.ObterPorId(id);

            if (produto is null)
                return NotFound();

            var response = ProdutoMapper.MapearParaResponse(produto);
            return CustomResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(CreateProdutoRequest createProdutoRequest)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produto = ProdutoMapper.MapearParaEntidade(createProdutoRequest);
            await _produtoService.Adicionar(produto);

            var response = ProdutoMapper.MapearParaCreateResponse(produto);

            return CustomResponse(HttpStatusCode.Created, response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, UpdateProdutoRequest updateProdutoRequest)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (id != updateProdutoRequest.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse(HttpStatusCode.BadRequest);
            }

            var produto = ProdutoMapper.MapearParaEntidade(updateProdutoRequest);
            await _produtoService.Atualizar(produto);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _produtoService.Remover(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }
    }
}
