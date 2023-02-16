using LS.Cavaliere.Models;

namespace LS.Cavaliere.AspNetCore.ViewModels.Dogs;

public record DogDetailViewModel(Dog Dog, IEnumerable<string?> FileNames);