namespace Task.Application.CommandsQueries.Handlers
{
    public class GetTaskQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<DomainTask>>
    {
        private readonly IDomainTaskRepository _domainTask;

        public GetTaskQueryHandler(IDomainTaskRepository domainTask)
        {
            _domainTask = domainTask;
        }
        public async Task<IEnumerable<DomainTask>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            return await _domainTask.GetTaks();
        }
    }
}
