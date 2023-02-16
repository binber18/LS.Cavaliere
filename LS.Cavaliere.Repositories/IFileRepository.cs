using LS.Cavaliere.Models.Results;

namespace LS.Cavaliere.Repositories;

public interface IFileRepository
{
    Task<FileResult?> GetFileAsync(string directory, string fileName);
    Task SaveFileAsync(string directory, string fileName, Stream content, string fileContentType);
    Task UpdateFileAsync(string directory, string fileName, Stream content, string fileContentType);
    string GetDirectoryNameForDogImages(Guid dogId);
    Task<IEnumerable<string>> GetFileNamesInDirectory(string directoryName);
    Task<bool> DeleteFileFromDirectory(string directoryName, string fileName);
    string GetDirectoryNameForLitterImages(Guid litterId);
    string GetDirectoryNameForPuppyImages(Guid id);
}