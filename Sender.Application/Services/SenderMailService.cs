using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;


namespace Sender.Application.Services
{
    public class SenderMailService : ISenderMailService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SenderMailService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Create(SenderMailDto senderMailDto)
        {
            var senderCreate = _mapper.Map<SenderMailCreateCommand>(senderMailDto);
            await _mediator.Send(senderCreate);
        }

        public async Task Delete(int? id)
        {
            var senderRemove = new SenderMailDeleteCommand(id.Value);

            if (senderRemove == null)
                throw new Exception($"Entity could not be loader!");

            await _mediator.Send(senderRemove);
        }

        public async Task<IEnumerable<SenderMailDto>> GetMails()
        {
            var senderMail = new GetMailsQuery();

            if (senderMail == null) throw new Exception($"Entity could not be loaded!");

            var result = await _mediator.Send(senderMail);

            return _mapper.Map<IEnumerable<SenderMailDto>>(result);
        }
        public async Task Update(SenderMailDto senderMailDto)
        {
            var senderUpdate = _mapper.Map<SenderMailUpdateCommand>(senderMailDto);
            await _mediator.Send(senderUpdate);
        }

        public async Task<SenderMailDto> GetMailById(int? id)
        {
            var senderMail = new GetMailByIdQuery(id.Value);

            if (senderMail == null)
            {
                throw new Exception($"Entity could not be loaded");
            }

            var result = await _mediator.Send(senderMail);

            return _mapper.Map<SenderMailDto>(result);
        }

        //TODO Implementar o Envio e e-mails.

        public Task SendMails()
        {
            throw new NotImplementedException();
        }

        public async Task<SenderMailDto> SendById(SenderMailDto senderMailDto)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(senderMailDto.SenderConfig.Sender_user));
                email.To.Add(MailboxAddress.Parse(senderMailDto.Sender_email));
                email.Subject = senderMailDto.Sender_title;
                email.Body = new TextPart(senderMailDto.Sender_message) { Text = senderMailDto.Sender_message };

                //SendEmail
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(senderMailDto.SenderConfig.Sender_smtp, int.Parse(senderMailDto.SenderConfig.Sender_port), SecureSocketOptions.None);
                await smtp.AuthenticateAsync(senderMailDto.SenderConfig.Sender_user, senderMailDto.SenderConfig.Sender_password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return senderMailDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"EmailServiceException {ex.Message}");
            }
        }
    }
}
