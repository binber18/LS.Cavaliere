using System.ComponentModel.DataAnnotations;

namespace LS.Cavaliere.Models.Requests.Dogs;

public record UpdateDogRequest(Guid Id, string Name, [DataType(DataType.Date)] DateTime Birthday, string Father, string Mother, string? Description, string? TitleImage, IEnumerable<string> Images)
{
    public static UpdateDogRequest FromDog(Dog dog, string? titleImage, IEnumerable<string> images)
        => new(dog.Id, dog.Name, dog.BirthDay, dog.Father, dog.Mother, dog.Description, titleImage, images);
}