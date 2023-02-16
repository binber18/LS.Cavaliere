namespace LS.Cavaliere.Services.Identity.Models;

public class LoginResult
{
    public static readonly LoginResult NoResult = new(false, false, string.Empty);
    public static readonly LoginResult SuccessResult = new(true, false, string.Empty);
    public static readonly LoginResult WrongUsernameOrPassword = new(false, true, "Wrong username or password");
    private LoginResult(bool success, bool fail, string error)
    {
        Success = success;
        Fail = fail;
        Error = error;
    }
    public bool Success { get; }
    public bool Fail { get; }
    public string Error { get; }
}