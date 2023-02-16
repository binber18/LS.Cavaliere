using LS.Cavaliere.Models.Results;

namespace LS.Cavaliere.Services;

internal interface IInternalFileService : IFileService
{
    Task<IEnumerable<string>> GetDogImagesAsync(Guid dogId);
    Task<string> SaveDogImageAsync(Guid dogId, string fileName, Stream image, string contentType);
    Task<bool> DeleteDogImageAsync(Guid dogId, string fileName);
    Task<string> SaveLitterImageAsync(Guid litterId, string fileName, Stream image, string contentType);
    Task<string?> GetFirstImageAsync(Guid dogId);
    Task<string> SavePuppyImageAsync(Guid id, string fileName, Stream imageContent, string imageContentType);
}

public interface IFileService
{
    Task<FileResult?> GetDogImageAsync(Guid dogId, string fileName);
    Task<FileResult?> GetLitterImageAsync(Guid litterId, string fileName);
    Task<FileResult?> GetPuppyImageAsync(Guid puppyId, string fileName);
}