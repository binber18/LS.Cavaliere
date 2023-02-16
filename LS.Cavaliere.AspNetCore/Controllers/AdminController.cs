using LS.Cavaliere.AspNetCore.ViewModels.Admin;
using LS.Cavaliere.Services.Identity;
using LS.Cavaliere.Services.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LS.Cavaliere.AspNetCore.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IUserService _userService;
    private readonly ILogger<AdminController> _logger;

    public AdminController(IUserService userService, ILogger<AdminController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet, AllowAnonymous]
    public IActionResult Login()
    {
        return View(new LoginViewModel(LoginResult.NoResult, new("", "")));
    }

    [HttpPost, AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel loginVm)
    {
        _logger.LogInformation("User {Username} is trying to login", loginVm.LoginRequest.Username);
        var login = loginVm.LoginRequest;
        var loginResult = await _userService.LoginAsync(login);
        
        if (loginResult.Success)
            return RedirectToAction(nameof(Index), "Home");

        return View(new LoginViewModel(loginResult, login));
    }

    public async Task<IActionResult> Logout()
    {
        await _userService.LogoutAsync();
        return RedirectToAction("Login");
    }
}