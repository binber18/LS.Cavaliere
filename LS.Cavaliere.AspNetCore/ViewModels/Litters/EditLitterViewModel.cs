using LS.Cavaliere.Models;
using LS.Cavaliere.Models.Requests.Litters;

namespace LS.Cavaliere.AspNetCore.ViewModels.Litters;

public record EditLitterViewModel(Guid Id, char Letter, string Father, string Mother, string? Description, DateTime? LitterDate)
{
    public static EditLitterViewModel FromLitter(Litter litter)
    {
        return new(litter.Id, litter.Letter, litter.Father, litter.Mother, litter.Description, litter.LitterDate);
    }

    public UpdateLitterRequest ToUpdateLitterRequest()
    {
        return new(Mother, Father, Description, LitterDate);
    }
}