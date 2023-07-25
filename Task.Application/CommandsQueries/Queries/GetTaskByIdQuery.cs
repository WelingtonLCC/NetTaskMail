
namespace Task.Application.CommandsQueries.Queries
{
    public class GetTaskByIdQuery : IRequest<DomainTask>
    {
        public int DomainTask_id { get; set; }

        public GetTaskByIdQuery(int id)
        {
            this.DomainTask_id = id;
        }
    }
}
