
namespace Sender.Application.CommandQueries.SenderMail.Queries
{
    public class GetMailByIdQuery : IRequest<SenderMailDomain>
    {
        public int Sender_Id { get; set; }

        public GetMailByIdQuery(int id)
        {
            this.Sender_Id = id;
        }
    }
}
