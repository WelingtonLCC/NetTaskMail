using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sender.Application.Interfaces;
using Sender.Application.Mappings;
using Sender.Application.Services;
using Sender.Domain.Interfaces;
using Sender.InfraData.Context;
using Sender.InfraData.Repositories;

namespace Sender.InfraIoc
{
    public static class SenderDependencyInjection
    {
        public static IServiceCollection AddInfrastructureSender(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SenderApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ISenderConfigService,SenderConfigService >();
            services.AddScoped<ISenderConfigDomain, SenderConfigRepository > ();
            services.AddScoped<ISenderMailService, SenderMailService>();
            services.AddScoped<ISenderMailDomain, SenderMailRepository>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("Sender.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
