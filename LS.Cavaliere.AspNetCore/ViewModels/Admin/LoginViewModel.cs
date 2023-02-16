using LS.Cavaliere.Models.Requests.Auth;
using LS.Cavaliere.Services.Identity.Models;

namespace LS.Cavaliere.AspNetCore.ViewModels.Admin;

public record LoginViewModel(LoginResult LoginResult, LoginRequest LoginRequest);
