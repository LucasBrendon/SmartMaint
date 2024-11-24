using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.Comandos.Criar;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.Consultas.ConsultarPorCep;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.Consultas.ListarEnderecos;
using SmartMaint.Compartilhado.ApiResponse;

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
            return Ok(GenericResponse.SuccessResponse(await _mediator.Send(command), "Endereço criado com sucesso!"));
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(GenericResponse.SuccessResponse(await _mediator.Send(new ListarEnderecosQuery())));
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> BuscarPorCep(string cep)
        {
            var result = await _mediator.Send(new ConsultarEnderecoPorCepQuery { Cep = cep });

            return result is not null ? Ok(GenericResponse.SuccessResponse(result)) : NoContent();
        }
    }
}
