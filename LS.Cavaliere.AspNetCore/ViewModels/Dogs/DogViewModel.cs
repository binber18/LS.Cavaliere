using LS.Cavaliere.Models;

namespace LS.Cavaliere.AspNetCore.ViewModels.Dogs;

public record DogViewModel(Dog Dog, string? ImageFileName);