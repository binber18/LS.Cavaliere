using Microsoft.AspNetCore.Http;

namespace LS.Cavaliere.Models.Requests.Files;

public record FileRequest(string FileName, Stream Content, string ContentType)
{
    public static FileRequest FromFormFile(IFormFile file)
    {
        return new FileRequest(GetSafeFileName(file.FileName), file.OpenReadStream(), file.ContentType);
    }
    public static string GetSafeFileName(string fileName)
    {
        var id = Guid.NewGuid();
        return $"{id}{Path.GetExtension(fileName)}";
    }

    public FileRecord ToFileRecord(string? title = null, string? description = null)
    {
        return FileRecord.FromFile(FileName, ContentType, title ?? FileName, description);
    }
}