using Mapster;
using MediatR;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.ViewModels;
using SmartMaint.Aplicacao.Interfaces.Repositorios;

namespace SmartMaint.Aplicacao.Aplicacao.Enderecos.Consultas.ListarEnderecos
{
    public class ListarEnderecosQueryHandler : IRequestHandler<ListarEnderecosQuery, List<EnderecoViewModel>>
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public ListarEnderecosQueryHandler(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        public async Task<List<EnderecoViewModel>> Handle(ListarEnderecosQuery request, CancellationToken cancellationToken)
        {
            var enderecos = await _enderecoRepositorio.Listar();

            return enderecos.Adapt<List<EnderecoViewModel>>();
        }
    }
}
