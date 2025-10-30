using Microsoft.EntityFrameworkCore;

namespace StoreApp.Data.Concrete;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders{ get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
           .HasMany(e => e.Categories)
           .WithMany(e => e.Products)
           .UsingEntity<ProductCategory>();
            
        modelBuilder.Entity<Category>()
            .HasIndex(u => u.Url)
            .IsUnique();

        modelBuilder.Entity<Product>().HasData(
            new List<Product>()
            {
                new() {Id=1, Name="Samsung S24", Description="High performance telephone", Price=50000},
                new() {Id=2, Name="Samsung S25", Description="High performance telephone", Price=60000},
                new() {Id=3, Name="Samsung S26", Description="High performance telephone", Price=70000},
                new() {Id=4, Name="Samsung S27", Description="High performance telephone", Price=80000},
                new() {Id=5, Name="Samsung S28", Description="High performance telephone", Price=90000},
                new() {Id=6, Name="Samsung S29", Description="High performance telephone", Price=100000},
                new() {Id=7, Name="Phlips Washing Machine", Description="ZLast technology washing machine", Price=100000},

            }

        );

        modelBuilder.Entity<Category>().HasData(
            new List<Category>()
            {
                new() {Id=1, Name="Telephone", Url="telephone"},
                new() {Id=2, Name="Electronic", Url="electronic"},
                new() {Id=3, Name="Furniture", Url="furniture"},
            }
        );
        
        modelBuilder.Entity<ProductCategory>().HasData(
           new List<ProductCategory>()
           {
            new ProductCategory(){ ProductId=1, CategoryId=1},
            new ProductCategory(){ ProductId=1, CategoryId=2},
            new ProductCategory(){ ProductId=2, CategoryId=1},
            new ProductCategory(){ ProductId=3, CategoryId=1},
            new ProductCategory(){ ProductId=4, CategoryId=1},
            new ProductCategory(){ ProductId=5, CategoryId=2},
            new ProductCategory(){ ProductId=6, CategoryId=2},
            new ProductCategory(){ ProductId=7, CategoryId=3},
           }
        );
    }
}