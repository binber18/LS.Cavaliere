using LS.Cavaliere.Models;

namespace LS.Cavaliere.Repositories;

public interface IPuppyRepository
{
    Task CreatePuppyAsync(Puppy puppy);
    Task SetPuppyImageAsync(Guid puppyId, string fileName);
}