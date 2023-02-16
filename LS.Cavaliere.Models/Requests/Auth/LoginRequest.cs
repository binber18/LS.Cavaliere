using System.ComponentModel.DataAnnotations;

namespace LS.Cavaliere.Models.Requests.Auth;

public record LoginRequest(string Username, [DataType(DataType.Password)] string Password, bool Persistent = false);