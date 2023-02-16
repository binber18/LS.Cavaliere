using LS.Cavaliere.Models.Requests.Files;

namespace LS.Cavaliere.Models.Requests.Dogs;

public record CreateDogRequest(string Name, DateTime Birthday, string Mother, string Father, string? Description, FileRequest Image);