using LS.Cavaliere.Services.Identity.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace LS.Cavaliere.Services.Identity;

public static class ServiceCollectionExtensions
{
    public static  IServiceCollection AddIdentityServices(this  IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
