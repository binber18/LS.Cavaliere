using LS.Cavaliere.Models;
using LS.Cavaliere.Repositories;
using Microsoft.Extensions.Logging;

namespace LS.Cavaliere.EntityFrameworkCore.Implementations;

internal class EntityFrameworkPuppyRepository : IPuppyRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<EntityFrameworkPuppyRepository> _logger;

    public EntityFrameworkPuppyRepository(ApplicationDbContext context, ILogger<EntityFrameworkPuppyRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task CreatePuppyAsync(Puppy puppy)
    {
        _logger.LogTrace("Creating Puppy {Puppy}", puppy);
        _context.Puppies.Add(puppy);
        await _context.SaveChangesAsync();
    }

    public async Task SetPuppyImageAsync(Guid puppyId, string fileName)
    {
        _logger.LogTrace("Setting Puppy Image '{FileName}' for Puppy with id '{PuppyId}'", fileName, puppyId);
        var puppy = await _context.Puppies.FindAsync(puppyId);
        if (puppy is null)
        {
            _logger.LogWarning("Puppy with Id '{PuppyId}' not found", puppyId);
            return;
        }
        puppy.Image = fileName;
        await _context.SaveChangesAsync();
    }
}