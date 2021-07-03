using FluentValidation;
using FluentValidation.Results;
using NegocieOnline.Business.Core.Models;
using NegocieOnline.Business.Core.Notifications;

namespace NegocieOnline.Business.Core.Service
{
    public abstract class BaseService
    {
        private readonly INotification _notification;

        protected BaseService(INotification notification)
        {
            _notification = notification;
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade)
            where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);
            
            return false;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Notificar(erro.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notification.Handle(new Notifications.Notifications(mensagem));
        }
    }
}