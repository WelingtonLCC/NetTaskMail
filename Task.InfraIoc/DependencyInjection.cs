using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Task.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Task.Application.Mappings;
using Task.Application.Interfaces;
using Task.Application.Services;
using Task.domain.Interfaces;
using Task.InfraData.Repositories;

namespace Task.InfraIoc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IDomainTaskService, DomainTaskService>();
            services.AddScoped<IDomainTaskRepository, TaskRepository>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            

            var myHandlers = AppDomain.CurrentDomain.Load("Task.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
