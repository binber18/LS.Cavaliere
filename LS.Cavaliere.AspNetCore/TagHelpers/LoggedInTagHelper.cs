using LS.Cavaliere.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LS.Cavaliere.AspNetCore.TagHelpers;

[HtmlTargetElement("logged-in")]
public class LoggedInTagHelper : TagHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly SignInManager<AppUser> _signInManager;
    public LoggedInTagHelper(IHttpContextAccessor httpContextAccessor, SignInManager<AppUser> signInManager)
    {
        _httpContextAccessor = httpContextAccessor;
        _signInManager = signInManager;
    }

    override public void Process(TagHelperContext context, TagHelperOutput output)
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user is null || !_signInManager.IsSignedIn(user))
        {
            output.SuppressOutput();
            return;
        }
        base.Process(context, output);
    }
}

[HtmlTargetElement("not-logged-in")]
public class NotLoggedInTagHelper : TagHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly SignInManager<AppUser> _signInManager;

    public NotLoggedInTagHelper(IHttpContextAccessor httpContextAccessor, SignInManager<AppUser> signInManager)
    {
        _httpContextAccessor = httpContextAccessor;
        _signInManager = signInManager;
    }

    override public void Process(TagHelperContext context, TagHelperOutput output)
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user is not null && _signInManager.IsSignedIn(user))
        {
            output.SuppressOutput();
            return;
        }

        base.Process(context, output);
    }
}