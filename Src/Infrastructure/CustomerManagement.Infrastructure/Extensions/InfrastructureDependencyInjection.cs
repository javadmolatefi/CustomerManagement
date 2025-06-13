using CustomerManagement.Application.Common.Identity;
using CustomerManagement.Domain.Interfaces;
using CustomerManagement.Infrastructure.Identity;
using CustomerManagement.Infrastructure.Persistence;
using CustomerManagement.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDbContext<IdentityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }
}
