namespace LS.Cavaliere.Models;

public class FileRecord
{
    public static FileRecord FromFile(string fileName, string contentType, string title, string? description = null)
    {
        return new FileRecord
        {
            Id = Guid.NewGuid() + Path.GetExtension(fileName),
            ContentType = contentType,
            Title = title,
            Description = description,
        };
    }
    public required string Id { get; init; }
    public required string ContentType { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
}