using DevIO.Domain.Notifications;

namespace DevIO.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Manipular(Notificacao notificacao);
    }
}
