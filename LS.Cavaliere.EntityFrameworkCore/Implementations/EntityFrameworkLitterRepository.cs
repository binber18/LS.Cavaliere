using LS.Cavaliere.Models;
using LS.Cavaliere.Models.Requests.Litters;
using LS.Cavaliere.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LS.Cavaliere.EntityFrameworkCore.Implementations;

internal class EntityFrameworkLitterRepository : ILitterRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<EntityFrameworkLitterRepository> _logger;
    public EntityFrameworkLitterRepository(ApplicationDbContext context, ILogger<EntityFrameworkLitterRepository> logger)
    {
        _context = context;
        _logger = logger;

    }
    public async Task<IEnumerable<Litter>> GetAllLittersAsync()
    {
        _logger.LogTrace("Getting All Litters");
        return await _context.Litters
                             .OrderBy(x => x.Letter)
                             .ToListAsync();
    }
    public async Task<Litter?> GetByIdAsync(Guid id)
    {
        _logger.LogTrace("Retrieving Litter with id '{Id}' from database", id);
        return await _context.Litters
                             .Include(l => l.Puppies)
                             .FirstOrDefaultAsync(l => l.Id == id);
    }
    public async Task<char> GetLastLetterAsync()
    {
        var letter = await _context.Litters
                                   .OrderByDescending(x => x.Letter)
                                   .Select(x => x.Letter)
                                   .FirstOrDefaultAsync();
        if (letter == default)
            letter = 'Z';
        _logger.LogTrace("Getting Last Litter Letter: '{Letter}'", letter);
        return letter;
    }
    public async Task CreateAsync(Litter litter)
    {
        _logger.LogTrace("Creating Litter {@Litter}", litter);
        _context.Litters.Add(litter);
        await _context.SaveChangesAsync();
    }
    public async Task SetHeroImageAsync(Guid litterId, string fileName)
    {
        _logger.LogTrace("Setting Hero Image for Litter with id '{Id}' to '{FileName}'", litterId, fileName);
        var litter = await _context.Litters.FindAsync(litterId);
        if (litter is null)
            return;
        litter.HeroImage = fileName;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Guid id, UpdateLitterRequest updateRequest)
    {
        _logger.LogTrace("Updating Litter with id '{Id}' {@UpdateRequest}", id, updateRequest);
        var litter = await _context.Litters.FindAsync(id);
        if (litter is null)
            return;
        litter.Father = updateRequest.Father;
        litter.Mother = updateRequest.Mother;
        litter.Description = updateRequest.Description;
        litter.LitterDate = updateRequest.LitterDate;
        await _context.SaveChangesAsync();
    }
}