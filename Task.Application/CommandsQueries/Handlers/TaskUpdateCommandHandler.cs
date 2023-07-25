
namespace Task.Application.CommandsQueries.Handlers
{
    public class TaskUpdateCommandHandler : IRequestHandler<TaskUpdateCommand, DomainTask>
    {
        private readonly IDomainTaskRepository _domainTask;

        public TaskUpdateCommandHandler(IDomainTaskRepository domainTask)
        {
            _domainTask = domainTask?? 
                throw new ArgumentNullException(nameof(domainTask));
        }

        public async Task<DomainTask> Handle(TaskUpdateCommand request, CancellationToken cancellationToken)
        {
            var taskDomain = await _domainTask.GetById(request.DomainTask_id);

            if (taskDomain == null)
            {
                throw new ApplicationException($"Entity could not found");
            }else
            {
                taskDomain.Update(request.Description, request.OpenIn, request.Forecast);
                return await _domainTask.Update(taskDomain);
            }
        }
    }
}
