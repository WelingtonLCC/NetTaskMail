
namespace Sender.Application.CommandQueries.SenderConfig.Handlers
{
    public class SenderConfigCreateCommandHandler : IRequestHandler<SenderConfigCreateCommand, SenderConfigDomain>
    {
        private readonly ISenderConfigDomain _domain;

        public SenderConfigCreateCommandHandler(ISenderConfigDomain domain)
        {
            _domain = domain;
        }
        public async Task<SenderConfigDomain> Handle(SenderConfigCreateCommand request, CancellationToken cancellationToken)
        {
            var senderConfig = new SenderConfigDomain(request.Sender_user, request.Sender_smtp, request.Sender_password, request.Sender_port);

            if (senderConfig == null)
                throw new ApplicationException($"Error creating entity");
            else
                return await _domain.Create(senderConfig);
            
        }
    }
}
