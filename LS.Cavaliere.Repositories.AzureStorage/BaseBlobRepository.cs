using Azure.Storage.Blobs;
using Microsoft.Extensions.Logging;

namespace LS.Cavaliere.Repositories.AzureStorage;

internal abstract class BaseBlobRepository<TImpl>
where TImpl : BaseBlobRepository<TImpl>
{
    private readonly BlobServiceClient _client;
    private readonly ILogger<TImpl> _logger;
    // ReSharper disable once ContextualLoggerProblem
    protected BaseBlobRepository(BlobServiceClient client, ILogger<TImpl> logger)
    {
        _client = client;
        _logger = logger;
    }
    protected async Task<BlobContainerClient> GetContainerClient(string containerName)
    {
        _logger.LogTrace("Getting container {ContainerName} from Azure Storage", containerName);
        var containerClient = _client.GetBlobContainerClient(containerName.ToLower());
        if (await containerClient.ExistsAsync())
        {
            _logger.LogTrace("Container {ContainerName} already exists in Azure Storage", containerName);
            return containerClient;
        }
        _logger.LogTrace("Creating container {ContainerName} in Azure Storage", containerName);
        return await _client.CreateBlobContainerAsync(containerName);
    }
    
    protected async Task<BlobClient> GetBlobClient(string containerName, string blobName)
    {
        var containerClient = await GetContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(blobName);
        return blobClient;
    }
}
