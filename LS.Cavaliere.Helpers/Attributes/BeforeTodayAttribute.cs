using System.ComponentModel.DataAnnotations;

namespace LS.Cavaliere.Helpers.Attributes;

public class BeforeTodayAttribute : ValidationAttribute
{
    public BeforeTodayAttribute()
        : base(() => "Date must be before today")
    {
    }
    public override bool IsValid(object? value)
    {
        if (value is not DateTime date)
            return false;

        return date <= DateTime.Today;
    }
}