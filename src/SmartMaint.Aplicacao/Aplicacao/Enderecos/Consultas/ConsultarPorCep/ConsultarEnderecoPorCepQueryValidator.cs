using FluentValidation;

namespace SmartMaint.Aplicacao.Aplicacao.Enderecos.Consultas.ConsultarPorCep
{
    public class ConsultarEnderecoPorCepQueryValidator : AbstractValidator<ConsultarEnderecoPorCepQuery>
    {
        public ConsultarEnderecoPorCepQueryValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Cep)
                .NotEmpty()
                .WithMessage("Cep deve ser informado.")
                .Length(8, 8)
                .WithMessage("Cep deve conter 8 caracteres.");
        }
    }
}
