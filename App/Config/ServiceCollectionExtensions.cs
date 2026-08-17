using crud_sharp.App.Data;
using crud_sharp.App.Services;
using Microsoft.EntityFrameworkCore;

namespace crud_sharp.App.Config;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<IssDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Iss")));

        services.AddDbContext<PortalDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Portal")));

        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IMasterCompanyService, MasterCompanyService>();
        services.AddScoped<IMasterDeptService, MasterDeptService>();
        services.AddScoped<IMasterProjectService, MasterProjectService>();

        return services;
    }
}
