
namespace Task.Application.CommandsQueries.Handlers
{
    public class TaskCreateCommandHandler : IRequestHandler<TaskCreateCommand, DomainTask>
    {
        private readonly IDomainTaskRepository _domainTask;

        public TaskCreateCommandHandler(IDomainTaskRepository domainTask)
        {
            _domainTask = domainTask;   
        }
        public async Task<DomainTask> Handle(TaskCreateCommand request, CancellationToken cancellationToken)
        {
            var taskDomain = new DomainTask(request.Description, request.OpenIn, request.Forecast);

            if (taskDomain == null)
            {
                throw new ApplicationException($"Error cresting entity");
            }
            else
            {
                return await _domainTask.Create(taskDomain);
            }
        }
    }
}
