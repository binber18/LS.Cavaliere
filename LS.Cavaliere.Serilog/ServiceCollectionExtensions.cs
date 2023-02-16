using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace LS.Cavaliere.Serilog;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
                    .ConfigureForCavaliere(builder.Configuration)
                    .CreateBootstrapLogger();

        builder.Host.UseSerilog(
        (context, services, configuration)
            => configuration
              .ConfigureForCavaliere(context.Configuration)
              .Enrich.With(new ControllerEnricher(services.GetRequiredService<IHttpContextAccessor>()))
              .ReadFrom.Services(services)
              .WriteTo.Console(outputTemplate:"[{Timestamp:HH:mm:ss} {Level:u3}] ({SourceContext}) - {Message:lj}{NewLine}{Exception}"));

        return builder;
    }
    
    public static IApplicationBuilder UseSerilog(this IApplicationBuilder app)
    {
        return app.UseSerilogRequestLogging();
    }

    private static LoggerConfiguration ConfigureForCavaliere(this LoggerConfiguration loggerConfig, IConfiguration configuration)
    {
        return loggerConfig
              .ReadFrom.Configuration(configuration)
              .Enrich.FromLogContext();
    }
}