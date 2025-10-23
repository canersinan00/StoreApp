using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concrete;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new List<Product>()
            {
                new() {Id=1, Name="Samsung S24", Description="High performance telephone", Price=50000, Category="Telephone"},
                new() {Id=2, Name="Samsung S25", Description="High performance telephone", Price=60000, Category="Telephone"},
                new() {Id=3, Name="Samsung S26", Description="High performance telephone", Price=70000, Category="Telephone"},
                new() {Id=4, Name="Samsung S27", Description="High performance telephone", Price=80000, Category="Telephone"},
                new() {Id=5, Name="Samsung S28", Description="High performance telephone", Price=90000, Category="Telephone"},
                new() {Id=6, Name="Samsung S29", Description="High performance telephone", Price=100000, Category="Telephone"},
            }

        );
    }
}