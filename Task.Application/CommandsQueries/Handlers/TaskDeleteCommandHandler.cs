
namespace Task.Application.CommandsQueries.Handlers
{
    public class TaskDeleteCommandHandler : IRequestHandler<TaskDeleteCommand, DomainTask>
    {
        private readonly IDomainTaskRepository _domainTask;

        public TaskDeleteCommandHandler(IDomainTaskRepository domainTask)
        {
            _domainTask = domainTask?? 
                throw new ArgumentNullException(nameof(domainTask));
        }
        public async Task<DomainTask> Handle(TaskDeleteCommand request, CancellationToken cancellationToken)
        {
            var taskDomain = await _domainTask.GetById(request.DomainTask_id); 

            if (taskDomain == null) { 
                throw new ApplicationException($"Entity could not found");
            }else
            {
                var result = await _domainTask.Delete(taskDomain);

                return result;
            }
        }
    }
}
