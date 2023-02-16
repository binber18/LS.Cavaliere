namespace LS.Cavaliere.Models.Results;

public record FileResult(string FileName, Stream Content, string ContentType);