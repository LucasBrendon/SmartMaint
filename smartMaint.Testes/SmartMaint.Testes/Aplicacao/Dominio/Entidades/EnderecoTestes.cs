using Bogus;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using SmartMaint.Dominio.Entidades;

namespace SmartMaint.Testes.Aplicacao.Dominio.Entidades
{
    public class EnderecoTestes
    {
        private readonly Faker _faker = new("pt_BR");

        [Fact]
        [Trait("Abordagem", "Faker")]
        public void Faker_Construtor_DadoTodosOsParametros_DeveDevolverTodasAsPropriedadesCorretas()
        {
            //Arrenge
            var cepEsperado = _faker.Address.ZipCode();
            var logradouroEsperado = _faker.Address.StreetName();
            var bairroEsperado = _faker.Address.City();
            var localidadeEsperada = _faker.Address.City();
            var ufEsperado = _faker.Address.StateAbbr();

            //Act
            var endereco = new Endereco(cepEsperado, logradouroEsperado, bairroEsperado, localidadeEsperada, ufEsperado);

            //Assert
            Assert.Equal(cepEsperado, endereco.Cep);
            Assert.Equal(logradouroEsperado, endereco.Logradouro);
            Assert.Equal(bairroEsperado, endereco.Bairro);
            Assert.Equal(localidadeEsperada, endereco.Localidade);
            Assert.Equal(ufEsperado, endereco.Uf);
        }

        [Fact]
        [Trait("Abordagem", "Faker_FluentAssertion")]
        public void Faker_FluentAssertion_Construtor_DadoTodosOsParametros_DeveDevolverTodasAsPropriedadesCorretas()
        {
            //Arrenge
            var cepEsperado = _faker.Address.ZipCode();
            var logradouroEsperado = _faker.Address.StreetName();
            var bairroEsperado = _faker.Address.City();
            var localidadeEsperada = _faker.Address.City();
            var ufEsperado = _faker.Address.StateAbbr();

            //Act
            var endereco = new Endereco(cepEsperado, logradouroEsperado, bairroEsperado, localidadeEsperada, ufEsperado);

            //Assert
            endereco.Cep.Should().Be(cepEsperado);
            endereco.Logradouro.Should().Be(logradouroEsperado);
            endereco.Bairro.Should().Be(bairroEsperado);
            endereco.Localidade.Should().Be(localidadeEsperada);
            endereco.Uf.Should().Be(ufEsperado);
        }

        [Fact]
        [Trait("Abordagem", "NoFaker")]
        public void NoFaker_Construtor_DadoTodosOsParametros_DeveDevolverTodasAsPropriedadesCorretas()
        {
            //Arrenge
            var cepEsperado = "35680063";
            var logradouroEsperado = "Rua João Cerqueira Lima";
            var bairroEsperado = "Centro";
            var localidadeEsperada = "Itaúna";
            var ufEsperado = "MG";

            //Act
            var endereco = new Endereco(cepEsperado, logradouroEsperado, bairroEsperado, localidadeEsperada, ufEsperado);

            //Assert
            Assert.Equal(cepEsperado, endereco.Cep);
            Assert.Equal(logradouroEsperado, endereco.Logradouro);
            Assert.Equal(bairroEsperado, endereco.Bairro);
            Assert.Equal(localidadeEsperada, endereco.Localidade);
            Assert.Equal(ufEsperado, endereco.Uf);
        }

        [Theory]
        [Trait("Abordagem", "Theory_NoFaker")]
        [InlineData("Divinópolis")]
        [InlineData("Pará de Minas")]
        public void Theory_NoFaker_Construtor_DadoTodosOsParametros_DeveDevolverTodasAsPropriedadesCorretas(string logradouroEsperado)
        {
            //Arrenge
            var cepEsperado = "35680063";
            var bairroEsperado = "Centro";
            var localidadeEsperada = "Itaúna";
            var ufEsperado = "MG";

            //Act
            var endereco = new Endereco(cepEsperado, logradouroEsperado, bairroEsperado, localidadeEsperada, ufEsperado);

            //Assert
            Assert.Equal(cepEsperado, endereco.Cep);
            Assert.Equal(logradouroEsperado, endereco.Logradouro);
            Assert.Equal(bairroEsperado, endereco.Bairro);
            Assert.Equal(localidadeEsperada, endereco.Localidade);
            Assert.Equal(ufEsperado, endereco.Uf);
        }
    }
}
