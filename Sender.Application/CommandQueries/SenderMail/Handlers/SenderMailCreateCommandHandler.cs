using Sender.Application.CommandQueries.SenderMail.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender.Application.CommandQueries.SenderMail.Handlers
{
    public class SenderMailCreateCommandHandler : IRequestHandler<SenderMailCreateCommand, SenderMailDomain>
    {
        private readonly ISenderMailDomain _senderMailDomain;

        public SenderMailCreateCommandHandler(ISenderMailDomain senderMailDomain)
        {
            _senderMailDomain = senderMailDomain;
        }
        public async Task<SenderMailDomain> Handle(SenderMailCreateCommand request, CancellationToken cancellationToken)
        {
            var senderMail = new SenderMailDomain(request.Sender_title, request.Sender_email, request.Sender_message);

            if (senderMail == null)
                throw new ApplicationException($"Error creating Entity");
            else
                return await _senderMailDomain.Create(senderMail);
        }
    }
}
