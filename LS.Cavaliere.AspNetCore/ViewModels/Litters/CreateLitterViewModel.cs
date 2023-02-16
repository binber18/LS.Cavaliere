using System.ComponentModel.DataAnnotations;

namespace LS.Cavaliere.AspNetCore.ViewModels.Litters;

public class CreateLitterViewModel
{
    [Required]
    public char Letter { get; set; }
    public required IEnumerable<char> ValidLetters { get; set; }
    [Required]
    public IFormFile? ParentImage { get; set; }
    [Required(AllowEmptyStrings = false)]
    public string Mother { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string Father { get; set; } = string.Empty;
}