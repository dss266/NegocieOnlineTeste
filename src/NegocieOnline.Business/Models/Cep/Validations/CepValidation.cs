using FluentValidation;

namespace NegocieOnline.Business.Models.Cep.Validations
{
    public class CepValidation:AbstractValidator<Cep>
    {
        public CepValidation()
        {
            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(8).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres ");
        }
    }
}