using FluentValidation;
using SmartMaint.Aplicacao.Interfaces.Repositorios;

namespace SmartMaint.Aplicacao.Aplicacao.Enderecos.Comandos.Criar
{
    public class CriarEnderecoCommandValidator : AbstractValidator<CriarEnderecoCommand>
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public CriarEnderecoCommandValidator(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Cep)
                .NotEmpty()
                .WithMessage("Cep não foi informado.")
                .Length(8, 8)
                .WithMessage("Cep deve conter 8 caracteres.")
                .MustAsync(ValidarCepExistente)
                .WithMessage("Cep já cadastrado.");

            RuleFor(x => x.Logradouro)
                .NotEmpty()
                .WithMessage("Logradouro não foi informado.")
                .MaximumLength(250)
                .WithMessage("Logradouro deve conter no máximo 250 caracteres.");

            RuleFor(x => x.Bairro)
                .NotEmpty()
                .WithMessage("Bairro não foi informando.")
                .MaximumLength(100)
                .WithMessage("Bairro deve conter no máximo 100 caracteres.");

            RuleFor(x => x.Localidade)
                .NotEmpty()
                .WithMessage("Localidade não foi informando.")
                .MaximumLength(100)
                .WithMessage("Localidade deve conter no máximo 100 caracteres.");

            RuleFor(x => x.Uf)
                .NotEmpty()
                .WithMessage("UF não foi informado.")
                .Length(2, 2)
                .WithMessage("UF deve conter e 2 caracteres.");
        }

        private async Task<bool> ValidarCepExistente(string cep, CancellationToken token)
        {
            var endereco = await _enderecoRepositorio.ConsultarPorCep(cep);

            return endereco is null;
        }
    }
}
