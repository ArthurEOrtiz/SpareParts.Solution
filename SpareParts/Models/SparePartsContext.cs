using Microsoft.EntityFrameworkCore;

namespace SpareParts.Models
{
  public class SparePartsContext : DbContext
  {
    public DbSet<Vehicle> Vehicles { get; set; }

    public SparePartsContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}