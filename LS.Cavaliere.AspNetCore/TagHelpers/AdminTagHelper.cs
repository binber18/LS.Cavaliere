using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LS.Cavaliere.AspNetCore.TagHelpers;

[HtmlTargetElement("admin")]
public class AdminTagHelper : TagHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AdminTagHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    override public void Process(TagHelperContext context, TagHelperOutput output)
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user is null || !user.IsInRole("Admin"))
        {
            output.SuppressOutput();
            return;
        }
        base.Process(context, output);
    }
}