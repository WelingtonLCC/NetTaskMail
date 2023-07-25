
namespace Task.Application.Interfaces
{
    public interface IDomainTaskService
    {
        Task<IEnumerable<DomainTaskDto>> GetTasks();
        Task<DomainTaskDto> GetById(int? id);

        TTask Update(DomainTaskDto domainTaskDto);
        TTask Create(DomainTaskDto domainTaskDto);
        TTask Delete(int? id);
    }
}
