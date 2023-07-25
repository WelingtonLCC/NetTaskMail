
namespace Sender.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<SenderConfigDomain, SenderConfigDto>().ReverseMap();
            CreateMap<SenderMailDomain, SenderMailDto>().ReverseMap();
        }
    }
}
