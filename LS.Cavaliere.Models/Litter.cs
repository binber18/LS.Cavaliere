namespace LS.Cavaliere.Models;

public class Litter
{
    public required Guid Id { get; set; }
    public required char Letter { get; set; }
    public required string Father { get; set; }
    public required string Mother { get; set; }
    public string? HeroImage { get; set; }
    public required DateTime? LitterDate { get; set; } 
    public List<Puppy> Puppies { get; set; } = new();
    public string? Description { get; set; }
}