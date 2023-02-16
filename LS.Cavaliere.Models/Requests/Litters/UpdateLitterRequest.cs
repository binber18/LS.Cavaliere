namespace LS.Cavaliere.Models.Requests.Litters;

public record UpdateLitterRequest(string Mother, string Father, string? Description, DateTime? LitterDate);