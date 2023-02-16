namespace LS.Cavaliere.AspNetCore.ViewModels.Litters;

public record AddPuppyToLitterViewModel(Guid Id, string Name, IFormFile? Image);