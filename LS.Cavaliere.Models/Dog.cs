namespace LS.Cavaliere.Models;

public class Dog
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string? TitleImage { get; set; }
    public required DateTime BirthDay { get; set; }
    public required string Mother { get; set; }
    public required string Father { get; set; }
    public string? Description { get; set; }
}