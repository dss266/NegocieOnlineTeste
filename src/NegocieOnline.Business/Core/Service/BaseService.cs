using FluentValidation;
using NegocieOnline.Business.Core.Models;

namespace NegocieOnline.Business.Core.Service
{
    public abstract class BaseService 
    {
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade)
            where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            return validator.IsValid;
        }
    }
}