using MediatR;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.ViewModels;

namespace SmartMaint.Aplicacao.Aplicacao.Enderecos.Consultas.ListarEnderecos
{
    public class ListarEnderecosQuery : IRequest<List<EnderecoViewModel>>
    {
    }
}
