using FluentValidation;

namespace SmartMaint.Aplicacao.Aplicacao.Enderecos.Comandos.Criar
{
    public class CriarEnderecoCommandValidator : AbstractValidator<CriarEnderecoCommand>
    {
        public CriarEnderecoCommandValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Cep)
                .NotEmpty()
                .WithMessage("Cep não foi informado")
                .Length(8, 8)
                .WithMessage("Cep deve conter 8 caracteres.");

            RuleFor(x => x.Logradouro)
                .NotEmpty()
                .WithMessage("Logradouro não foi informado.")
                .MaximumLength(250)
                .WithMessage("Logradouro deve conter no máximo 250 caracteres.");

        }
    }
}
