using LS.Cavaliere.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LS.Cavaliere.EntityFrameworkCore;

internal class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Dog> Dogs => Set<Dog>();
    public DbSet<Litter> Litters => Set<Litter>();
    public DbSet<Puppy> Puppies => Set<Puppy>();
}