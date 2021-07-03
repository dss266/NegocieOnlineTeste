using System.Collections.Generic;
using System.Linq;

namespace NegocieOnline.Business.Core.Notifications
{
    public class Notificador:INotification
    {
        private List<Notifications> _notifications;

        public Notificador()
        {
            _notifications = new List<Notifications>();
        }
        public bool TemNotificacao()
        {
            return _notifications.Any();
        }

        public List<Notifications> ObterNotificacoes()
        {
            return _notifications;
        }

        public void Handle(Notifications notifications)
        {
            _notifications.Add(notifications);
        }
    }
}