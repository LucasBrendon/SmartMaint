using MediatR;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.ViewModels;

namespace SmartMaint.Aplicacao.Aplicacao.Enderecos.Comandos.Criar
{
    public class CriarEnderecoCommand : IRequest<EnderecoViewModel>
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
    }
}
