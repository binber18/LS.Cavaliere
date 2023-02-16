namespace LS.Cavaliere.Models;

public class Puppy
{
    public required Guid LitterId { get; set; }
    public Litter? Litter { get; set; }
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Image { get; set; }
}