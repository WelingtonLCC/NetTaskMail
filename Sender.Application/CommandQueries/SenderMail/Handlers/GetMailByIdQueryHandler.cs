using Sender.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender.Application.CommandQueries.SenderMail.Handlers
{
    public class GetMailByIdQueryHandler : IRequestHandler<GetMailByIdQuery, SenderMailDomain>
    {
        private readonly ISenderMailDomain _senderMailDomain;
        public GetMailByIdQueryHandler(ISenderMailDomain senderMailDomain)
        {
            _senderMailDomain = senderMailDomain;
        }

        public async Task<SenderMailDomain> Handle(GetMailByIdQuery request, CancellationToken cancellationToken)
        {
            return await _senderMailDomain.GetMailById(request.Sender_Id);
        }
    }
}
