using LS.Cavaliere.Helpers.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LS.Cavaliere.AspNetCore.ViewModels.Admin;

public class CreateDogViewModel
{
    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; } = string.Empty;
    [DataType(DataType.Date), BeforeToday, NotOlderThan(days: 365 * 30, ShowRelative = true)]
    public DateTime Birthday { get; set; }
    [Required(AllowEmptyStrings = false)]
    public string Mother { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string Father { get; set; } = string.Empty;
    public string? Description { get; set; }
    [Required,DataType(DataType.Upload)]
    public IFormFile Image { get; set; } = null!;
}