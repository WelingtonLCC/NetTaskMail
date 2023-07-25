
namespace Sender.Application.CommandQueries.SenderMail.Commands
{
    public abstract class SenderMailCommand : IRequest<SenderMailDomain>
    {
        public string Sender_title { get; private set; }
        public string Sender_email { get; private set; }
        public string Sender_message { get; private set; }
    }
}
