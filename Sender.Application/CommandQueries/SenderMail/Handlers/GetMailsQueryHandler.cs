
namespace Sender.Application.CommandQueries.SenderMail.Handlers
{
    public class GetMailsQueryHandler : IRequestHandler<GetMailsQuery, IEnumerable<SenderMailDomain>>
    {
        private readonly ISenderMailDomain _senderMailDomain;

        public GetMailsQueryHandler(ISenderMailDomain senderMailDomain)
        {
            _senderMailDomain = senderMailDomain;
        }
        public async Task<IEnumerable<SenderMailDomain>> Handle(GetMailsQuery request, CancellationToken cancellationToken)
        {
            return await _senderMailDomain.GetMails();
        }
    }
}
