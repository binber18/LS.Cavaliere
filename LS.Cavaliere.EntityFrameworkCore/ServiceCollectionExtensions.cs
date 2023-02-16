using LS.Cavaliere.EntityFrameworkCore.Implementations;
using LS.Cavaliere.Helpers;
using LS.Cavaliere.Models;
using LS.Cavaliere.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LS.Cavaliere.EntityFrameworkCore;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsActon = null)
    {
        services.AddDbContext<ApplicationDbContext>(optionsActon);

        services.AddScoped<IDogRepository, EntityFrameworkDogRepository>();
        services.AddScoped<ILitterRepository, EntityFrameworkLitterRepository>();
        services.AddScoped<IPuppyRepository, EntityFrameworkPuppyRepository>();

        return services;
    }

    public static IdentityBuilder AddEntityFrameworkIdentity(this IServiceCollection services, Action<IdentityOptions>? setupAction = null)
    {
        return services.AddIdentity<AppUser, IdentityRole>(setupAction)
                       .AddEntityFrameworkStores<ApplicationDbContext>();
    }

    public static async Task SeedDefaultAdmin(this IServiceProvider services, DefaultAdmin defaultAdmin)
    {
        using var scope = services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        var admins = await userManager.GetUsersInRoleAsync("Admin");
        if (admins.EmptyIfNull().Any())
            return;
        var user = new AppUser
        {
            UserName = defaultAdmin.UserName,
            Email = defaultAdmin.Email,
            EmailConfirmed = true,
        };
        var result = await userManager.CreateAsync(user, defaultAdmin.Password);
        if (!result.Succeeded)
            throw new Exception(result.Errors.First().Description);
        
        await userManager.AddToRoleAsync(user, "Admin");


    }
}