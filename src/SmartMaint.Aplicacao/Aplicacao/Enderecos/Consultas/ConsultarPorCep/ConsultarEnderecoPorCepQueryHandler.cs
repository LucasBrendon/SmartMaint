using Mapster;
using MediatR;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.ViewModels;
using SmartMaint.Aplicacao.Interfaces.Repositorios;

namespace SmartMaint.Aplicacao.Aplicacao.Enderecos.Consultas.ConsultarPorCep
{
    public class ConsultarEnderecoPorCepQueryHandler : IRequestHandler<ConsultarEnderecoPorCepQuery, EnderecoViewModel>
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public ConsultarEnderecoPorCepQueryHandler(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        public async Task<EnderecoViewModel> Handle(ConsultarEnderecoPorCepQuery request, CancellationToken cancellationToken)
        {
            var endereco = await _enderecoRepositorio.ConsultarPorCep(request.Cep);

            return endereco.Adapt<EnderecoViewModel>();
        }
    }
}
