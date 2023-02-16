using System.Runtime.CompilerServices;

namespace LS.Cavaliere.Helpers;

public static class NullableHelper
{
    public static T AssertNotNull<T>(this T? value, [CallerArgumentExpression(nameof(value))] string? argumentName = null)
        => value ?? throw new ArgumentNullException(argumentName);
}