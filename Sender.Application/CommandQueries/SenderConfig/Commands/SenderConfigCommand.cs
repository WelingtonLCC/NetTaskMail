
namespace Sender.Application.CommandQueries.SenderConfig.Commands
{
    public abstract class SenderConfigCommand : IRequest<SenderConfigDomain>
    {
        public string Sender_user { get; set; }
        public string Sender_smtp { get; set; }
        public string Sender_password { get; set; }
        public string Sender_port { get;  set; }
    }
}
