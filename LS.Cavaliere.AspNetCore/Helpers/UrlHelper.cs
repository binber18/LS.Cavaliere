using LS.Cavaliere.AspNetCore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace LS.Cavaliere.AspNetCore.Helpers;

public static class UrlHelper
{
    public static string? GetDogImageUrl(this IUrlHelper url, Guid dogId, string? fileName, bool noCache = false)
    {
        if (noCache)
        {
            return url.Action(nameof(FilesController.UncachedDog), "Files", new { dogId, fileName });
        }
        return url.Action(nameof(FilesController.Dog), "Files", new { dogId, fileName });
    }
    public static string? GetLitterImageUrl(this IUrlHelper url, Guid litterId, string? fileName, bool noCache = false)
    {
        if (noCache)
        {
            return url.Action(nameof(FilesController.UncachedLitter), "Files", new { id = litterId, fileName });
        }
        return url.Action(nameof(FilesController.Litter), "Files", new { id = litterId, fileName });
    }
    public static string? GetPuppyImageUrl(this IUrlHelper url, Guid puppyId, string? fileName, bool noCache = false)
    {
        if (noCache)
        {
            return url.Action(nameof(FilesController.UncachedPuppy), "Files", new { id = puppyId, fileName });
        }
        return url.Action(nameof(FilesController.Puppy), "Files", new { id = puppyId, fileName });
    }
}