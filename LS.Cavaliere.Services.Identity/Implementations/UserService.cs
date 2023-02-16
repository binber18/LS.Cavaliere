using LS.Cavaliere.Models;
using LS.Cavaliere.Models.Requests.Auth;
using LS.Cavaliere.Services.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace LS.Cavaliere.Services.Identity.Implementations;

internal class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public async Task<LoginResult> LoginAsync(LoginRequest login)
    {
        var user = await _userManager.FindByNameAsync(login.Username);
        user ??= await _userManager.FindByEmailAsync(login.Username);

        if (user is null)
            return LoginResult.WrongUsernameOrPassword;
        

        var isCorrectPassword = await _signInManager.PasswordSignInAsync(login.Username, login.Password, login.Persistent, false);

        if (!isCorrectPassword.Succeeded)
            return LoginResult.WrongUsernameOrPassword;

        await _signInManager.SignInAsync(user, login.Persistent);
        return LoginResult.SuccessResult;
    }
    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}