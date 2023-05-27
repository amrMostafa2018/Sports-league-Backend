using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nafes.CrossCutting.Data.Repository;
using Task.Application.Contracts;
using Task.Application.Lookups.Contracts;
using Task.Application.Lookups.Implamention;
using Task.DatabaseMigration;
using Task.Services.Implementation;
using Task.Shared.Data.Repository;
using Microsoft.AspNetCore.Identity;


namespace Task.Application
{
    public static class ConfigureDependencyInjectionServices
    {
        public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TaskSharedDbContext>(options =>
                            options.UseSqlServer(
                                configuration.GetConnectionString("ConnectionString"), builder => builder.EnableRetryOnFailure()

                                    ));



            services.AddDbContext<TaskDbContext>(options =>
            { options.UseSqlServer(configuration.GetConnectionString("ConnectionString"), builder => builder.EnableRetryOnFailure()); });
          
            services.AddScoped(typeof(ISharedRepository<,>), typeof(SharedRepository<,>));
            services.AddScoped(typeof(ILookupService<>), typeof(LookupService<>));
            services.AddScoped(typeof(UserManager<>), typeof(UserManager<>));

   
            services.AddScoped<ITeamService, TeamService>();     
            services.AddScoped<ITeamMemberService, TeamMemberService>();     
            services.AddScoped<ITeamScheduleService, TeamScheduleService>();     

            return services;
        }
    }
}
