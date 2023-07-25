

namespace Task.domain.Interfaces
{
    public interface  IDomainTaskRepository
    {
        Task<IEnumerable<DomainTask>> GetTaks();

        Task<DomainTask> GetById(int? id);

        Task<DomainTask> Create(DomainTask domainTask);
        Task<DomainTask> Update(DomainTask domainTask);
        Task<DomainTask> Delete(DomainTask domainTask);
    }
}
