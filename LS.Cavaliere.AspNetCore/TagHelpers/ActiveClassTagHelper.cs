using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Diagnostics.CodeAnalysis;
using System.Text.Encodings.Web;
using System.Web;

namespace LS.Cavaliere.AspNetCore.TagHelpers;

[HtmlTargetElement("a")]
public class ActiveClassTagHelper : TagHelper
{
    override public int Order => int.MaxValue;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly LinkGenerator _linkGenerator;
    private readonly ILogger<ActiveClassTagHelper> _logger;
    public ActiveClassTagHelper(IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator, ILogger<ActiveClassTagHelper> logger)
    {
        _httpContextAccessor = httpContextAccessor;
        _linkGenerator = linkGenerator;
        _logger = logger;
    }
    override public void Process(TagHelperContext context, TagHelperOutput output)
    {
        var href = GetHref(context);
        if (!IsCurrentPage(href))
            return;

        var classes = output.Attributes.FirstOrDefault(a => a.Name == "class")?.Value.ToString();
        if (classes is null)
        {
            output.Attributes.Add("class", "active");
            return;
        }
        output.Attributes.SetAttribute("class", classes + " active");
    }

    private bool IsCurrentPage([NotNullWhen(true)] string? href)
    {
        var path = _httpContextAccessor.HttpContext?.Request.Path.Value;
        path = HttpUtility.UrlDecode(path);
        if (string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(href))
            return false;
        _logger.LogTrace("Comparing href {Href} to path {Path}", href, path);
        if (href == "/")
            return path == "/";
        return path.StartsWith(href, StringComparison.InvariantCultureIgnoreCase);
    }

    private string? GetHref(TagHelperContext context)
    {
        var href = !context.AllAttributes.TryGetAttribute("href", out var hrefAttr)
                       ? GetHrefFromControllerAndAction(context)
                       : hrefAttr.Value.ToString();
        return HttpUtility.UrlDecode(href);
    }

    private string? GetHrefFromControllerAndAction(TagHelperContext context)
    {
        var controller = context.AllAttributes["asp-controller"]?.Value.ToString();
        var action = context.AllAttributes["asp-action"]?.Value.ToString();
        if (action is null)
            return null;
        return _linkGenerator.GetPathByAction(action, controller ?? _httpContextAccessor.HttpContext?.Request.RouteValues["controller"]?.ToString() ?? "");
    }
}