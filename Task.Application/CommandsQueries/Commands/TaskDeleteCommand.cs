
namespace Task.Application.CommandsQueries.Commands
{
    public class TaskDeleteCommand : TaskCommand
    {
        public int DomainTask_id { get; set; }

        public TaskDeleteCommand(int id)
        {
            DomainTask_id = id;
        }
    }
}
