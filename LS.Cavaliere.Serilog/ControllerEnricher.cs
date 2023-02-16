using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace LS.Cavaliere.Serilog;

public class ControllerEnricher : ILogEventEnricher
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ControllerEnricher(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        
        var context = _httpContextAccessor.HttpContext;
        if(context is null)
            return;
        var controllerName = context.Request.RouteValues["controller"]?.ToString();
        var controller = propertyFactory.CreateProperty("Controller", controllerName, true);
        logEvent.AddOrUpdateProperty(controller);
    }
}
