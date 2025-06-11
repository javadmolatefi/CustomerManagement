using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
