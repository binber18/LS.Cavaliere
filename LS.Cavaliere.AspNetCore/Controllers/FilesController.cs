using LS.Cavaliere.Services;
using Microsoft.AspNetCore.Mvc;

namespace LS.Cavaliere.AspNetCore.Controllers;

[Route("[controller]")]
public class FilesController : Controller
{
    private readonly IFileService _fileService;
    private readonly ILogger<FilesController> _logger;
    public FilesController(IFileService fileService, ILogger<FilesController> logger)
    {
        _fileService = fileService;
        _logger = logger;
    }
    
    [HttpGet("Dog/{dogId:guid}"), ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> Dog(Guid dogId, string fileName)
    {
        _logger.LogTrace("Getting dog image for dog '{DogId}' with name '{Name}'", dogId, fileName);
        if (string.IsNullOrWhiteSpace(fileName))
            return BadRequest();
        var file = await _fileService.GetDogImageAsync(dogId, fileName);
        if (file is null)
            return NotFound();
        return File(file.Content, file.ContentType, file.FileName);
    }
    
    [HttpGet("Dog/NoCache/{dogId:guid}"), ResponseCache(NoStore = true)]
    public async Task<IActionResult> UncachedDog(Guid dogId, string fileName)
    {
        _logger.LogTrace("Getting dog image for dog '{DogId}' with name '{Name}'", dogId, fileName);
        if (string.IsNullOrWhiteSpace(fileName))
            return BadRequest();
        var file = await _fileService.GetDogImageAsync(dogId, fileName);
        if (file is null)
            return NotFound();
        return File(file.Content, file.ContentType, file.FileName);
    }
    
    [HttpGet("Litter/{id:guid}"), ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> Litter(Guid id, string fileName)
    {
        _logger.LogTrace("Getting litter image for litter '{LitterId}' with name '{Name}'", id, fileName);
        if (string.IsNullOrWhiteSpace(fileName))
            return BadRequest();
        var file = await _fileService.GetLitterImageAsync(id, fileName);
        if (file is null)
            return NotFound();
        return File(file.Content, file.ContentType, file.FileName);
    }
    
    [HttpGet("Litter/NoCache/{id:guid}"), ResponseCache(NoStore = true)]
    public async Task<IActionResult> UncachedLitter(Guid id, string fileName)
    {
        _logger.LogTrace("Getting uncached litter image for litter '{LitterId}' with name '{Name}'", id, fileName);
        if (string.IsNullOrWhiteSpace(fileName))
            return BadRequest();
        var file = await _fileService.GetLitterImageAsync(id, fileName);
        if (file is null)
            return NotFound();
        return File(file.Content, file.ContentType, file.FileName);
    }
    
    [HttpGet("Puppy/{id:guid}"), ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> Puppy(Guid id, string fileName)
    {
        _logger.LogTrace("Getting puppy image for puppy '{LitterId}' with name '{Name}'", id, fileName);
        if (string.IsNullOrWhiteSpace(fileName))
            return BadRequest();
        var file = await _fileService.GetPuppyImageAsync(id, fileName);
        if (file is null)
            return NotFound();
        return File(file.Content, file.ContentType, file.FileName);
    }
    
    [HttpGet("Puppy/NoCache/{id:guid}"), ResponseCache(NoStore = true)]
    public async Task<IActionResult> UncachedPuppy(Guid id, string fileName)
    {
        _logger.LogTrace("Getting uncached puppy image for puppy '{LitterId}' with name '{Name}'", id, fileName);
        if (string.IsNullOrWhiteSpace(fileName))
            return BadRequest();
        var file = await _fileService.GetPuppyImageAsync(id, fileName);
        if (file is null)
            return NotFound();
        return File(file.Content, file.ContentType, file.FileName);
    }
}
