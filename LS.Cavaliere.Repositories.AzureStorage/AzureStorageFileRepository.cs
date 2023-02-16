using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using LS.Cavaliere.Models.Results;
using Microsoft.Extensions.Logging;

namespace LS.Cavaliere.Repositories.AzureStorage;

internal class AzureStorageFileRepository : BaseBlobRepository<AzureStorageFileRepository>, IFileRepository
{
    private readonly ILogger<AzureStorageFileRepository> _logger;
    public AzureStorageFileRepository(BlobServiceClient client, ILogger<AzureStorageFileRepository> logger) 
        : base(client, logger)
    {
        _logger = logger;
    }

    public async Task<FileResult?> GetFileAsync(string directory, string fileName)
    {
        _logger.LogTrace("Getting file from Azure Storage {Directory}/{FileName}", directory, fileName);
        var blobClient = await GetBlobClient(directory, fileName);
        if (!await blobClient.ExistsAsync())
            return null;
        var response = await blobClient.DownloadStreamingAsync();
        return new FileResult(fileName, response.Value.Content, response.Value.Details.ContentType);
    }

    public async Task SaveFileAsync(string directory, string fileName, Stream content, string fileContentType)
    {
        _logger.LogTrace("Saving file to Azure Storage {Directory}/{FileName}", directory, fileName);
        var blobClient = await GetBlobClient(directory, fileName);
        await blobClient.UploadAsync(content, new BlobHttpHeaders { ContentType = fileContentType });
    }
    public async Task UpdateFileAsync(string directory, string fileName, Stream content, string fileContentType)
    {
        directory = directory.ToLower();
        fileName = fileName.ToLower();
        _logger.LogTrace("Saving file to Azure Storage {Directory}/{FileName}", directory, fileName);
        var blobClient = await GetBlobClient(directory, fileName);
        await blobClient.UploadAsync(content, new BlobHttpHeaders { ContentType = fileContentType });
    }
    public async Task<IEnumerable<string>> GetFileNamesInDirectory(string directoryName)
    {
        var containerClient = await GetContainerClient(directoryName);
        var blobs = containerClient.GetBlobs();
        return blobs.Select(b => b.Name);
    }
    public async Task<bool> DeleteFileFromDirectory(string directoryName, string fileName)
    {
        var blobClient = await GetBlobClient(directoryName, fileName);
        return await blobClient.DeleteIfExistsAsync();
    }
    public string GetDirectoryNameForLitterImages(Guid litterId)
    {
        return $"litter-images-{litterId}";
    }
    public string GetDirectoryNameForPuppyImages(Guid id)
    {
        return $"puppy-images-{id}";
    }

    public string GetDirectoryNameForDogImages(Guid dogId)
    {
        return "dog-images-" + dogId;
    }
}