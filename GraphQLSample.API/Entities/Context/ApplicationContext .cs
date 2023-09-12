using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.API.Entities.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SellerContextConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleContextConfiguration());
    }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
}
