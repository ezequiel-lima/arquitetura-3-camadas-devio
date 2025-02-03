using DevIO.Api.ViewModels;
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
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var produtos = await _produtoService.ObterTodos();
            return ProdutoMapper.MapearParaViewModel(produtos);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            var produto = await _produtoService.ObterPorId(id);

            if (produto is null)
                return NotFound();

            return ProdutoMapper.MapearParaViewModel(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produto = ProdutoMapper.MapearParaEntidade(produtoViewModel);
            await _produtoService.Adicionar(produto);

            return CustomResponse(HttpStatusCode.Created, produtoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produto = ProdutoMapper.MapearParaEntidade(produtoViewModel);
            await _produtoService.Atualizar(produto);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
        {
            await _produtoService.Remover(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }
    }
}
