using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.Comandos.Criar;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.Consultas.ListarEnderecos;

namespace SmartMaint.Api.Controllers
{
    [ApiController]
    [Route("api/enderecos")]
    public class EnderecoController : BaseController
    {
        public EnderecoController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarEnderecoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _mediator.Send(new ListarEnderecosQuery()));
        }
    }
}
