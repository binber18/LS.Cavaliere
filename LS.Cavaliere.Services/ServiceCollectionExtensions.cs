using LS.Cavaliere.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace LS.Cavaliere.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCavaliereServices(this IServiceCollection services)
    {
        services.AddScoped<IDogService, DogService>();
        services.AddScoped<ILitterService, LitterService>();
        services.AddScoped<IInternalFileService, FileService>();
        services.AddScoped<IFileService>(sp => sp.GetRequiredService<IInternalFileService>());
        return services;
    }
}