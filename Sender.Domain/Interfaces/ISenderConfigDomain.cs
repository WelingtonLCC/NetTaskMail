
namespace Sender.Domain.Interfaces
{
    public interface ISenderConfigDomain
    {
        Task<SenderConfigDomain> GetSender();
        Task<SenderConfigDomain> Create(SenderConfigDomain senderConfigDomain);
        Task<SenderConfigDomain> Update(SenderConfigDomain senderConfigDomain);
        Task<SenderConfigDomain> Delete(SenderConfigDomain senderConfigDomain);
    }
}
