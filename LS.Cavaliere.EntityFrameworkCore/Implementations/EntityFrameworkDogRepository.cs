using LS.Cavaliere.Models;
using LS.Cavaliere.Models.Requests.Dogs;
using LS.Cavaliere.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LS.Cavaliere.EntityFrameworkCore.Implementations;

internal class EntityFrameworkDogRepository : IDogRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<EntityFrameworkDogRepository> _logger;
    public EntityFrameworkDogRepository(ApplicationDbContext context, ILogger<EntityFrameworkDogRepository> logger)
    {
        _context = context;
        _logger = logger;

    }
    public async Task<IEnumerable<Dog>> GetAllDogsAsync()
    {
        _logger.LogTrace("Getting all dogs");
        return await _context.Dogs
                             .AsNoTracking()
                             .OrderBy(x => x.Name)
                             .ToListAsync();
    }
    public async Task<bool> CreateDogAsync(Dog dog)
    {
        _logger.LogTrace("Creating dog {DogName}", dog.Name);
        _context.Dogs.Add(dog);
        return await _context.SaveChangesAsync() > 0;
    }
    public Task<Dog?> GetDogByNameAsync(string name)
    {
        _logger.LogTrace("Getting dog by name {DogName}", name);
        return _context.Dogs
                       .FirstOrDefaultAsync(d => EF.Functions.Like(d.Name, name));
    }
    public async Task<Dog?> GetByIdAsync(Guid id)
    {
        _logger.LogTrace("Getting dog by id {DogId}", id);
        return await _context.Dogs
                             .FirstOrDefaultAsync(d => d.Id == id);
    }
    public async Task UpdateDogAsync(Guid id, UpdateDogRequest updateDogRequest)
    {
        _logger.LogTrace("Updating dog {DogId}", id);
        var dog = await _context.Dogs.FindAsync(id);
        if (dog is null)
        {
            _logger.LogWarning("Dog {DogId} not found", id);
            return;
        }
        dog.Name = updateDogRequest.Name;
        dog.Father = updateDogRequest.Father;
        dog.Mother = updateDogRequest.Mother;
        dog.BirthDay = updateDogRequest.Birthday;
        dog.Description = updateDogRequest.Description;
        await _context.SaveChangesAsync();
    }
    public async Task SetTitleImageForDogAsync(Guid dogId, string fileName)
    {
        _logger.LogTrace("Setting title image for dog {DogId}", dogId);
        var dog = await _context.Dogs.FindAsync(dogId);
        if (dog is null)
        {
            _logger.LogWarning("Dog {DogId} not found", dogId);
            return;
        }

        dog.TitleImage = fileName;
        await _context.SaveChangesAsync();
    }
}