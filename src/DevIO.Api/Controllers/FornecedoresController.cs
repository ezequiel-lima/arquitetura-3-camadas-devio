using DevIO.Api.Dto.Requests;
using DevIO.Api.Dto.Responses;
using DevIO.Api.Mappers;
using DevIO.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DevIO.Api.Controllers
{
    [Route("api/[controller]")]
    public class FornecedoresController : MainController
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedoresController(INotificador notificador, IFornecedorService fornecedorService) : base(notificador)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorResponse>>> ObterTodos()
        {
            var fornecedores = await _fornecedorService.ObterTodos();
            var response = FornecedorMapper.MapearParaResponse(fornecedores);
            return CustomResponse(HttpStatusCode.OK, response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorResponse>> ObterPorId(Guid id)
        {
            var fornecedor = await _fornecedorService.ObterPorId(id);

            if (fornecedor == null) 
                return NotFound();

            var response = FornecedorMapper.MapearParaDetailsResponse(fornecedor);
            return CustomResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(CreateFornecedorRequest createFornecedorRequest)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var fornecedor = FornecedorMapper.MapearParaEntidade(createFornecedorRequest);
            await _fornecedorService.Adicionar(fornecedor);

            var response = FornecedorMapper.MapearParaResponse(fornecedor);

            return CustomResponse(HttpStatusCode.Created, response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _fornecedorService.Remover(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }
    }
}
