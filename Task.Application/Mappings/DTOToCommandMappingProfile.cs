
namespace Task.Application.Mappings 
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<DomainTaskDto, TaskCreateCommand>();
            CreateMap<DomainTaskDto, TaskUpdateCommand>();
        }
       
    }
}
