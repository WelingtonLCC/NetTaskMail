
namespace Sender.Application.CommandQueries.SenderMail.Commands
{
    public class SenderMailDeleteCommand : IRequest<SenderMailDomain>
    {
        public int Id { get; set; }

        public SenderMailDeleteCommand(int id)
        {
            Id = id;   
        }
    }
}
