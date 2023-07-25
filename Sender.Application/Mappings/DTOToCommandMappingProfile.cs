



namespace Sender.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<SenderConfigDto, SenderConfigCreateCommand>();
            CreateMap<SenderConfigDto, SenderConfigUpdateCommand>();

            CreateMap<SenderMailDto, SenderMailCreateCommand>();
            CreateMap<SenderMailDto, SenderMailUpdateCommand>();
        }
    }
}
