
namespace Task.Application.CommandsQueries.Handlers
{
    public class GetTaskIdQueryHandler : IRequestHandler<GetTaskByIdQuery, DomainTask>
    {
        private readonly IDomainTaskRepository _domainTask;

        public GetTaskIdQueryHandler(IDomainTaskRepository domainTask)
        {
            _domainTask = domainTask;
        }

        public async Task<DomainTask> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _domainTask.GetById(request.DomainTask_id);
        }
    }
}
