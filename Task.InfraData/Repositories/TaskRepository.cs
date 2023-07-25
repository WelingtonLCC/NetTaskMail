
namespace Task.InfraData.Repositories
{
    public class TaskRepository : IDomainTaskRepository
    {
        private ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;   
        }

        public async Task<DomainTask> Create(DomainTask domainTask)
        {
            _context.Add(domainTask);
            await _context.SaveChangesAsync();
            return domainTask;
        }

        public async Task<DomainTask> GetById(int? id)
        {
            return await _context.Tarefas.SingleOrDefaultAsync(p => p.DomainTask_id == id);
        }

        public async Task<IEnumerable<DomainTask>> GetTaks()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<DomainTask> Delete(DomainTask domainTask)
        {
            _context.Remove(domainTask);
            await _context.SaveChangesAsync();
            return domainTask;
        }

        public async Task<DomainTask> Update(DomainTask domainTask)
        {
            _context.Update(domainTask);
            await _context.SaveChangesAsync();
            return domainTask;
        }
    }
}
