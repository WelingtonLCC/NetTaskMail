
namespace Task.Application.CommandsQueries.Commands
{
    public abstract class TaskCommand : IRequest<DomainTask>
    {
       /* public int DomainTask_id { get; set; }*/
        public string Description { get; set; }
        public DateTime OpenIn { get; private set; }
        public DateTime Forecast { get; private set; }

    }
}
