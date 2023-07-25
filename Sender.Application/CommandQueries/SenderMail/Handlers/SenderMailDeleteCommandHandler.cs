using Sender.Application.CommandQueries.SenderMail.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender.Application.CommandQueries.SenderMail.Handlers
{
    public class SenderMailDeleteCommandHandler : IRequestHandler<SenderMailDeleteCommand, SenderMailDomain>
    {
        private readonly ISenderMailDomain _senderMailDomain;

        public SenderMailDeleteCommandHandler(ISenderMailDomain senderMailDomain)
        {
            _senderMailDomain = senderMailDomain;
        }
        public async Task<SenderMailDomain> Handle(SenderMailDeleteCommand request, CancellationToken cancellationToken)
        {
            var senderMail = await _senderMailDomain.GetMailById(request.Id);

            if (senderMail == null)
                throw new ApplicationException($"Entity could not found");
            else
                return await _senderMailDomain.Delete(senderMail);
        }
    }
}
