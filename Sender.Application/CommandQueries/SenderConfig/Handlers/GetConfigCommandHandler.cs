
namespace Sender.Application.CommandQueries.SenderConfig.Handlers
{
    public class GetConfigCommandHandler : IRequestHandler<GetConfigQuery, SenderConfigDomain>
    {
        private readonly ISenderConfigDomain _domain;

        public GetConfigCommandHandler(ISenderConfigDomain domain)
        {
            _domain = domain;
        }
        public async Task<SenderConfigDomain> Handle(GetConfigQuery request, CancellationToken cancellationToken)
        {
            return await _domain.GetSender();
        }
    }
}
