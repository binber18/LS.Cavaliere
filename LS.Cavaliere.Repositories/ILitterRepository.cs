using LS.Cavaliere.Models;
using LS.Cavaliere.Models.Requests.Litters;

namespace LS.Cavaliere.Repositories;

public interface ILitterRepository
{
    Task<IEnumerable<Litter>> GetAllLittersAsync();
    Task<Litter?> GetByIdAsync(Guid id);
    Task<char> GetLastLetterAsync();
    Task CreateAsync(Litter litter);
    Task SetHeroImageAsync(Guid litterId, string fileName);
    Task UpdateAsync(Guid id, UpdateLitterRequest updateRequest);
}