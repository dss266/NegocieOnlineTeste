namespace NegocieOnline.Business.Core.Notifications
{
    public class Notifications
    {
        public Notifications(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; }
    }
}