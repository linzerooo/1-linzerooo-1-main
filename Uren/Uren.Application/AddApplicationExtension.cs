using Microsoft.Extensions.DependencyInjection;

namespace Finate.Application;

public static class AddApplicationExtension
{
    /// <summary>
    /// Подключение слоя приложения
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(AddApplicationExtension).Assembly));
        
        return services;
    }
}