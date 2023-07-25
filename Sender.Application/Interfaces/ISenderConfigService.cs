
namespace Sender.Application.Interfaces
{
    public interface ISenderConfigService
    {
        Task<SenderConfigDto> GetConfig();

        Task Update(SenderConfigDto senderConfigDto);
        Task Delete(int? id);
        Task Create(SenderConfigDto senderConfigDto);
    }
}
