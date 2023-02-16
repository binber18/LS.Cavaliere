using System.Diagnostics.CodeAnalysis;

namespace LS.Cavaliere.Helpers;

public static class EnumerableHelper
{
    public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T>? enumerable)
        => enumerable ?? Enumerable.Empty<T>();
    public static IEnumerable<T> NonNullElements<T>(this IEnumerable<T?> enumerable)
        where T : class
        => enumerable.Where(x => x is not null)!;
    public static bool IsNullOrEmpty<T>([NotNullWhen(true)] this IEnumerable<T>? enumerable)
        => enumerable is null || !enumerable.Any();

    public static IEnumerable<T> Repeat<T>(this T item, int count)
        => Enumerable.Repeat(item, count);

}

public static class StringHelper
{
    public static string Repeat(this char c, int count)
        => new(c, count);
}