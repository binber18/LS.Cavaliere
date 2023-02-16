using LS.Cavaliere.Models;
using LS.Cavaliere.Models.Requests.Litters;

namespace LS.Cavaliere.Services;

public interface ILitterService
{
    Task<IEnumerable<Litter>> GetAllLittersAsync();
    Task<Litter?> GetByIdAsync(Guid id);
    Task<char> GetNextLitterLetterAsync();
    ValueTask<IEnumerable<char>> GetValidLitterLettersAsync();
    Task CreateAsync(CreateLitterRequest request);
    Task UpdateAsync(Guid id, UpdateLitterRequest toUpdateLitterRequest);
    Task AddPuppyToLitterAsync(Guid litterId, AddPuppyToLitterRequest request);
}
