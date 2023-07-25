

namespace Sender.Application.Services
{
    public class SenderConfigService : ISenderConfigService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SenderConfigService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Create(SenderConfigDto senderConfigDto)
        {
            var senderConfig = new GetConfigQuery();

            if (senderConfig == null)
                throw new Exception($"Entity could not loader!");

            var result = await _mediator.Send(senderConfig);

            if (result == null)
            {
                var senderConfigCreate = _mapper.Map<SenderConfigCreateCommand>(senderConfigDto);
                await _mediator.Send(senderConfigCreate);
            }
            else
            {
                senderConfigDto.Sender_id = 0;
            }
        }

        public async Task Delete(int? id)
        {
            var senderRemove = new SenderConfigDeleteCommand(id.Value);

            if (senderRemove == null)
                throw new Exception($"Entity could nor be loaded!");

            await _mediator.Send(senderRemove);
        }

        public async Task<SenderConfigDto> GetConfig()
        {
            var senderConfig = new GetConfigQuery();

            if (senderConfig == null)
                throw new Exception($"Entity could not loader!");

            var result = await _mediator.Send(senderConfig);

            return _mapper.Map<SenderConfigDto>(result);
        }

        public async Task Update(SenderConfigDto senderConfigDto)
        {
            var senderUpdate = _mapper.Map<SenderConfigUpdateCommand>(senderConfigDto);
            await _mediator.Send(senderUpdate);
        }
    }
}
