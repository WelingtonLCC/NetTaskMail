
namespace Sender.Application.CommandQueries.SenderConfig.Commands
{
    public class SenderConfigDeleteCommand : IRequest<SenderConfigDomain>
    {
        public int SenderId { get; set; }

        public SenderConfigDeleteCommand(int id)
        {
            SenderId = id;
        }
    }
}
