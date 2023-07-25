
namespace Sender.Domain.Interfaces
{
    public interface ISenderMailDomain
    {
        Task<IEnumerable<SenderMailDomain>> GetMails();
        Task<SenderMailDomain> GetMailById(int id);
        
        Task<SenderMailDomain> Create(SenderMailDomain senderMailDomain);
        Task<SenderMailDomain> Delete(SenderMailDomain senderMailDomain);
        Task<SenderMailDomain> Update(SenderMailDomain senderMailDomain);
        Task<SenderMailDomain> SendID(SenderMailDomain senderMailDomain);
        Task<IEnumerable<SenderMailDomain>> SendMails();

    }
}
