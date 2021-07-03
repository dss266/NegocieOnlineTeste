using System.Collections.Generic;

namespace NegocieOnline.Business.Core.Notifications
{
    public interface INotification
    {
        bool TemNotificacao();
        List<Notifications> ObterNotificacoes();
        void Handle(Notifications notifications);
    }
}