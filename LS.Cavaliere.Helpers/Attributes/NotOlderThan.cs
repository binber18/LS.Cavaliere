using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LS.Cavaliere.Helpers.Attributes;

public class NotOlderThan : ValidationAttribute
{
    private readonly TimeSpan _timeSpan;
    private readonly DateTime _notBeforeDate;
    public bool ShowRelative { get; set; }
    public string DateFormatString { get; set; } = "F";
    public NotOlderThan(int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0)
    {
        var now = DateTime.Now;
        _notBeforeDate = now
                        .AddYears(-years)
                        .AddMonths(-months)
                        .AddDays(-days)
                        .AddHours(-hours)
                        .AddMinutes(-minutes)
                        .AddSeconds(-seconds);
        _timeSpan = now - _notBeforeDate;
    }

    override public string FormatErrorMessage(string name)
    {
        if (!ShowRelative)
            return $"Date must be after {_notBeforeDate:DateFormatString}";
        
        const string begin = "Date cannot be more than ";
        var sb = new StringBuilder(begin);
        if (_timeSpan.Days > 365)
            sb.Append($"{_timeSpan.Days / 365} Years");
        if (_timeSpan.Days % 365 > 0)
            sb.Append($"{_timeSpan.Days % 365} Days");
        if (_timeSpan.Hours > 0)
            sb.Append($"{_timeSpan.Hours} Hours");
        if (_timeSpan.Minutes > 0)
            sb.Append($"{_timeSpan.Minutes} Minutes");
        if (sb.Length > begin.Length)
            sb.Append(" and ");
        if (_timeSpan.Seconds > 0)
            sb.Append($"{_timeSpan.Seconds} Seconds");

        sb.Append("ago.");
        return sb.ToString();
    }
    public override bool IsValid(object? value)
    {
        if (value is not DateTime date)
            return false;
        var ago = DateTime.Now - date;
        return ago <= _timeSpan;
    }
}