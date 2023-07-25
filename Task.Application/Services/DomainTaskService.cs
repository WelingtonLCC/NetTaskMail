
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMessages.Domain;
using RabbitMQ.Client;
using System.Text;

namespace Task.Application.Services
{
    public class DomainTaskService : IDomainTaskService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        private readonly ConnectionFactory _factory;
        private readonly RabbitMqConfiguration _config;


        public DomainTaskService(IMapper mapper, IMediator mediator, IOptions<RabbitMqConfiguration> options)
        {
            _mapper = mapper;
            _mediator = mediator;

            _config = options.Value;

            _factory = new ConnectionFactory
            {
                HostName = _config.Host
            };
        }

        public async Task<IEnumerable<DomainTaskDto>> GetTasks()
        {
            var tasks = new GetTasksQuery();

            if(tasks == null)
            {
                throw new Exception($"Entity could not be loaded");
            }

            var result = await _mediator.Send(tasks);

            return _mapper.Map<IEnumerable<DomainTaskDto>>(result);
        }

        public async Task<DomainTaskDto> GetById(int? id)
        {
            var taskById = new GetTaskByIdQuery(id.Value);

            if (taskById == null)
            {
                throw new Exception($"Entity could not be loaded");
            }

            var result = await _mediator.Send(taskById);

            return _mapper.Map<DomainTaskDto>(result);
        }

        public async TTask Create(DomainTaskDto domainTaskDto)
        {
            var taskCommandCreate = _mapper.Map<TaskCreateCommand>(domainTaskDto);
            _mediator.Send(taskCommandCreate);

            RabbitPublish(domainTaskDto);
        }

        public async TTask Delete(int? id)
        {
            var taskDeleteCommand = new TaskDeleteCommand(id.Value);

            if (taskDeleteCommand == null)
                throw new Exception($"Entity could not be loaded");

            await _mediator.Send(taskDeleteCommand);
        }

        public async TTask Update(DomainTaskDto domainTaskDto)
        {
            var taskUpdateCommand = _mapper.Map<TaskUpdateCommand>(domainTaskDto);
            await _mediator.Send(taskUpdateCommand);
        }

        public async TTask RabbitPublish(DomainTaskDto domainTaskDto)
        { 
            using(var connection = _factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: _config.Queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false, 
                        arguments: null
                        );

                    var messageSerialized = JsonConvert.SerializeObject(domainTaskDto);
                    var messageBytes = Encoding.UTF8.GetBytes(messageSerialized);

                    channel.BasicPublish(
                        exchange: "", 
                        routingKey: _config.Queue, 
                        basicProperties: null, 
                        body: messageBytes
                        );
                }
            }
        }
    }
}
