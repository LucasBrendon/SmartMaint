using MediatR;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.ViewModels;

namespace SmartMaint.Aplicacao.Aplicacao.Enderecos.Consultas.ConsultarPorCep
{
    public class ConsultarEnderecoPorCepQuery : IRequest<EnderecoViewModel>
    {
        public string Cep { get; set; }
    }
}
