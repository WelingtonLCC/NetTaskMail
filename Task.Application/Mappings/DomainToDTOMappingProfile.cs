
namespace Task.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<DomainTask, DomainTaskDto>().ReverseMap();
            
        }
    }
}
