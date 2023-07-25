
namespace Sender.Application.CommandQueries.SenderConfig.Handlers
{
    public class SenderConfigUpdateCommandHandler : IRequestHandler<SenderConfigUpdateCommand, SenderConfigDomain>
    {
        private readonly ISenderConfigDomain _domain;

        public SenderConfigUpdateCommandHandler(ISenderConfigDomain domain)
        {
            _domain = domain;
        }
        public async Task<SenderConfigDomain> Handle(SenderConfigUpdateCommand request, CancellationToken cancellationToken)
        {
            var senderConfig = await _domain.GetSender();

            if (senderConfig == null)
                throw new ApplicationException($"Entity could not found");
            else
            {
                senderConfig.Update(request.Sender_user, request.Sender_smtp, request.Sender_password, request.Sender_port);

                return await _domain.Update(senderConfig);
            }
        }
    }
}
