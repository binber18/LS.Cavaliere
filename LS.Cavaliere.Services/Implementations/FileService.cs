using LS.Cavaliere.Models.Results;
using LS.Cavaliere.Repositories;
using Microsoft.Extensions.Logging;

namespace LS.Cavaliere.Services.Implementations;

internal class FileService : IInternalFileService
{
    private readonly IFileRepository _fileRepository;
    private readonly ILogger<FileService> _logger;
    public FileService(IFileRepository fileRepository, ILogger<FileService> logger)
    {
        _fileRepository = fileRepository;
        _logger = logger;

    }
    public async Task<IEnumerable<string>> GetDogImagesAsync(Guid dogId)
    {
        _logger.LogTrace("Getting Dog Images for Dog with id '{DogId}'", dogId);
        var directoryName = _fileRepository.GetDirectoryNameForDogImages(dogId);
        var fileNames = await _fileRepository.GetFileNamesInDirectory(directoryName);
        return fileNames;
    }
    public async Task<FileResult?> GetDogImageAsync(Guid dogId, string fileName)
    {
        _logger.LogTrace("Getting Dog Image '{FileName}' for Dog with id '{DogId}'", fileName, dogId);
        var directoryName = _fileRepository.GetDirectoryNameForDogImages(dogId);
        var file = await _fileRepository.GetFileAsync(directoryName, fileName);
        return file;
    }
    public Task<FileResult?> GetLitterImageAsync(Guid litterId, string fileName)
    {
        _logger.LogTrace("Getting Litter Image '{FileName}' for Litter with id '{LitterId}'", fileName, litterId);
        var directoryName = _fileRepository.GetDirectoryNameForLitterImages(litterId);
        return _fileRepository.GetFileAsync(directoryName, fileName);
    }
    public Task<FileResult?> GetPuppyImageAsync(Guid puppyId, string fileName)
    {
        _logger.LogTrace("Getting Puppy Image '{FileName}' for Puppy with id '{PuppyId}'", fileName, puppyId);
        var directoryName = _fileRepository.GetDirectoryNameForPuppyImages(puppyId);
        return _fileRepository.GetFileAsync(directoryName, fileName);
    }
    public async Task<string?> GetFirstImageAsync(Guid dogId)
    {
        _logger.LogTrace("Getting first Dog Image for Dog with id '{DogId}'", dogId);
        var directoryName = _fileRepository.GetDirectoryNameForDogImages(dogId);
        var files = await _fileRepository.GetFileNamesInDirectory(directoryName);
        return files.FirstOrDefault();

    }
    public async Task<string> SavePuppyImageAsync(Guid id, string fileName, Stream imageContent, string imageContentType)
    {
        _logger.LogTrace("Saving Puppy Image '{FileName}' for Puppy with id '{PuppyId}'", fileName, id);
        var directoryName = _fileRepository.GetDirectoryNameForPuppyImages(id);
        await _fileRepository.SaveFileAsync(directoryName, fileName, imageContent, imageContentType);
        return fileName;
    }
    public async Task<string> SaveDogImageAsync(Guid dogId, string name, Stream image, string contentType)
    {
        _logger.LogTrace("Saving Dog Image '{FileName}' for Dog with id '{DogId}'", name, dogId);
        var directoryName = _fileRepository.GetDirectoryNameForDogImages(dogId);
        await _fileRepository.SaveFileAsync(directoryName, name, image, contentType);
        return name;
    }
    public async Task<bool> DeleteDogImageAsync(Guid dogId, string fileName)
    {
        _logger.LogTrace("Deleting Dog Image '{FileName}' for Dog with id '{DogId}'", fileName, dogId);
        var directoryName = _fileRepository.GetDirectoryNameForDogImages(dogId);
        return await _fileRepository.DeleteFileFromDirectory(directoryName, fileName);
    }
    public async Task<string> SaveLitterImageAsync(Guid litterId, string fileName, Stream image, string contentType)
    {
        _logger.LogTrace("Saving Litter Image '{FileName}' for Litter with id '{LitterId}'", fileName, litterId);
        var directoryName = _fileRepository.GetDirectoryNameForLitterImages(litterId);
        await _fileRepository.SaveFileAsync(directoryName, fileName, image, contentType);
        return fileName;
    }
}