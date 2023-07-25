
namespace Sender.Application.Interfaces
{
    public interface ISenderMailService
    {
        Task<IEnumerable<SenderMailDto>> GetMails();

        Task<SenderMailDto> GetMailById(int? id);
        Task Create(SenderMailDto senderMailDto);
        Task Update(SenderMailDto senderMailDto);
        Task Delete(int? id);


        Task<SenderMailDto> SendById(SenderMailDto senderMailDto);
        Task SendMails();
        
    }
}
