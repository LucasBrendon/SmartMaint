using FluentAssertions;
using Moq;
using NSubstitute;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.Comandos.Criar;
using SmartMaint.Aplicacao.Aplicacao.Enderecos.ViewModels;
using SmartMaint.Aplicacao.Interfaces.Repositorios;
using SmartMaint.Dominio.Entidades;

namespace SmartMaint.Testes.Aplicacao.Aplicacao.Enderecos.Comandos.Criar
{
    public class CriarEnderecoCommandHandlerTestes
    {
        //private readonly CriarEnderecoCommandHandler _handler;

        //public CriarEnderecoCommandHandlerTestes()
        //{
        //    var enderecoRepository = Substitute.For<IEnderecoRepositorio>();
        //    _handler = new CriarEnderecoCommandHandler(enderecoRepository);
        //}

        //[Fact]
        //public async Task InformacoesDeInputValidas_DeveraRetornarUmEndereco()
        //{
        //    //Arrenge
        //    var criarEnderecoCommand = new CriarEnderecoCommand
        //    {
        //        Cep = "35680063",
        //        Logradouro = "Rua João Cerqueira Lima",
        //        Bairro = "Centro",
        //        Localidade = "Itaúna",
        //        Uf = "MG"
        //    };

        //    //Act
        //    var result = await _handler.Handle(criarEnderecoCommand, CancellationToken.None);


        //    //Assert
        //    result.Cep.Should().Be(criarEnderecoCommand.Cep);
        //}


        [Fact]
        public async Task DadoQueOsDadosDeEntradaOK_QuandoExecutado_RetornaEndereco()
        {
            //Arrange
            var enderecoRepositorio = new Mock<IEnderecoRepositorio>();

            var criarEnderecoCommand = new CriarEnderecoCommand
            {
                Cep = "35680063",
                Logradouro = "Rua João Cerqueira Lima",
                Bairro = "Centro",
                Localidade = "Itaúna",
                Uf = "MG"
            };

            var criarEnderecoCommandHandler = new CriarEnderecoCommandHandler(enderecoRepositorio.Object);

            //Act
            var result = await criarEnderecoCommandHandler.Handle(criarEnderecoCommand, CancellationToken.None);

            //Assert
            result.Cep.Should().Be(criarEnderecoCommand.Cep);

            enderecoRepositorio.Verify(e => e.Criar(It.IsAny<Endereco>()), Times.Once);
        }
    }
}
