using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace LS.Cavaliere.Repositories.AzureStorage;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAzureStorage(this IServiceCollection services, string connectionString)
    {
        services.AddAzureClients(builder => {
            builder.AddBlobServiceClient(connectionString);
        });
        
        services.AddSingleton<IFileRepository, AzureStorageFileRepository>();
        return services;
    }
}
