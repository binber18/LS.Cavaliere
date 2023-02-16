using LS.Cavaliere.Models;
using LS.Cavaliere.Models.Requests.Litters;
using LS.Cavaliere.Repositories;
using Microsoft.Extensions.Logging;

namespace LS.Cavaliere.Services.Implementations;

internal class LitterService : ILitterService
{
    private readonly ILitterRepository _litterRepository;
    private readonly IPuppyRepository _puppyRepository;
    private readonly IInternalFileService _fileService;
    private readonly ILogger<LitterService> _logger;
    public LitterService(ILitterRepository litterRepository,
                         IPuppyRepository puppyRepository,
                         IInternalFileService fileService,
                         ILogger<LitterService> logger)
    {
        _litterRepository = litterRepository;
        _puppyRepository = puppyRepository;
        _fileService = fileService;
        _logger = logger;
    }
    public async Task<IEnumerable<Litter>> GetAllLittersAsync()
    {
        _logger.LogTrace("Getting All Litters");
        return await _litterRepository.GetAllLittersAsync();
    }
    public async Task<Litter?> GetByIdAsync(Guid id)
    {
        _logger.LogTrace("Getting Litter with id '{Id}'", id);
        return await _litterRepository.GetByIdAsync(id);
    }
    public async Task<char> GetNextLitterLetterAsync()
    {
        var lastLetter = await _litterRepository.GetLastLetterAsync();
        if (lastLetter == 'Z')
            return 'A';
        return ++lastLetter;
    }
    public ValueTask<IEnumerable<char>> GetValidLitterLettersAsync()
    {
        return ValueTask.FromResult(Enumerable.Range('A', 'Z' - 'A').Select(x => (char)x));
    }
    public async Task CreateAsync(CreateLitterRequest request)
    {
        var litter = new Litter
        {
            Id = Guid.NewGuid(),
            Letter = request.Letter,
            Father = request.Father,
            Mother = request.Mother,
            LitterDate = default,
        };
        _logger.LogTrace("Creating Litter {@Litter}", litter);
        await _litterRepository.CreateAsync(litter);
        var fileName = await _fileService.SaveLitterImageAsync(litter.Id, request.ParentImage.FileName, request.ParentImage.Content, request.ParentImage.ContentType);
        await _litterRepository.SetHeroImageAsync(litter.Id, fileName);
    }
    public async Task UpdateAsync(Guid id, UpdateLitterRequest toUpdateLitterRequest)
    {
        _logger.LogTrace("Updating Litter with id '{Id}' with {@Litter}", id, toUpdateLitterRequest);
        await _litterRepository.UpdateAsync(id, toUpdateLitterRequest);
    }
    public async Task AddPuppyToLitterAsync(Guid litterId, AddPuppyToLitterRequest request)
    {
        var puppy = new Puppy
        {
            LitterId = litterId,
            Id = Guid.NewGuid(),
            Name = request.Name,
        };
        
        _logger.LogTrace("Adding Puppy {@Puppy} to Litter with id '{Id}'", puppy, litterId);

        await _puppyRepository.CreatePuppyAsync(puppy);
        var fileName = await _fileService.SavePuppyImageAsync(puppy.Id, request.Image.FileName, request.Image.Content, request.Image.ContentType);
        await _puppyRepository.SetPuppyImageAsync(puppy.Id, fileName);
    }
}