using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LS.Cavaliere.AspNetCore.TagHelpers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTagHelpers(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddTransient<ITagHelperComponent, ActiveClassTagHelper>();
        // services.AddTransient<ITagHelperComponent, AdminTagHelper>();
        // services.AddTransient<ITagHelperComponent, LoggedInTagHelper>();
        // services.AddTransient<ITagHelperComponent, NotLoggedInTagHelper>();
        return services;
    }
}
