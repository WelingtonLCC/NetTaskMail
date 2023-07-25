
namespace Sender.Application.CommandQueries.SenderConfig.Handlers
{
    public class SenderConfigDeleteCommandHandler : IRequestHandler<SenderConfigDeleteCommand, SenderConfigDomain>
    {
        private readonly ISenderConfigDomain _domain;

        public SenderConfigDeleteCommandHandler(ISenderConfigDomain domain)
        {
            _domain = domain;
        }
        public async Task<SenderConfigDomain> Handle(SenderConfigDeleteCommand request, CancellationToken cancellationToken)
        {
            var senderConfig = await _domain.GetSender();

            if (senderConfig == null)
                throw new ApplicationException($"Enity could not found");
            else
                return await _domain.Delete(senderConfig);

        }
    }
}
