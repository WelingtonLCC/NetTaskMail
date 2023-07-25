
using Sender.Application.CommandQueries.SenderMail.Commands;

namespace Sender.Application.CommandQueries.SenderMail.Handlers
{
    public class SenderMailUpdateCommandHandler : IRequestHandler<SenderMailUpdateCommand, SenderMailDomain>
    {
        private readonly ISenderMailDomain _senderMail;

        public SenderMailUpdateCommandHandler(ISenderMailDomain senderMail)
        {
            _senderMail = senderMail ??
                throw new ArgumentNullException(nameof(senderMail)); 
        }

        public async Task<SenderMailDomain> Handle(SenderMailUpdateCommand request, CancellationToken cancellationToken)
        {
            var senderMail = await _senderMail.GetMailById(request.Sender_id);

            if (senderMail == null)
            {
                throw new ApplicationException($"Entity could not found");
            }
            else
            {
                senderMail.Update(request.Sender_title, request.Sender_email, request.Sender_message);

                return await _senderMail.Update(senderMail);
            }
        }
    }
}
