using CustomerManagement.Application.Cities;
using CustomerManagement.Application.Customers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CustomerManagement.Application.Extensions;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<ICustomerFacade, CustomerFacade>();
        services.AddScoped<ICityFacade, CityFacade>();

        return services;
    }
}
