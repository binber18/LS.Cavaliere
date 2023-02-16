using LS.Cavaliere.Models.Requests.Auth;
using LS.Cavaliere.Services.Identity.Models;

namespace LS.Cavaliere.Services.Identity;

public interface IUserService
{
    Task<LoginResult> LoginAsync(LoginRequest login);
    Task LogoutAsync();
}