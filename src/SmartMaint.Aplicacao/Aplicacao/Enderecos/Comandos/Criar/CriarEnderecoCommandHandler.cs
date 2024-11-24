using Mapster;
using MediatR;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.ViewModels;
using SmartMaint.Aplicacao.Interfaces.Repositorios;
using SmartMaint.Dominio.Entidades;

namespace SmartMaint.Aplicacao.Aplicacao.Enderecos.Comandos.Criar
{
    public class CriarEnderecoCommandHandler : IRequestHandler<CriarEnderecoCommand, EnderecoViewModel>
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public CriarEnderecoCommandHandler(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        public async Task<EnderecoViewModel> Handle(CriarEnderecoCommand request, CancellationToken cancellationToken)
        {
            var endereco = new Endereco(request.Cep, request.Logradouro, request.Bairro, request.Localidade, request.Uf);

            await _enderecoRepositorio.Criar(endereco);

            return endereco.Adapt<EnderecoViewModel>();
        }
    }
}
