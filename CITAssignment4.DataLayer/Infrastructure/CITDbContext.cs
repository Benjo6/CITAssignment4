using CITAssignment4.DataLayer.Domain;
using Microsoft.EntityFrameworkCore;

namespace CITAssignment4.DataLayer.Infrastructure;

public class CITDbContext : DbContext
{
    public CITDbContext(DbContextOptions<CITDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetails>()
            .HasKey(od => new { od.OrderId, od.ProductId }); // Composite key
        
        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId);
        
        modelBuilder.Entity<Product>()
            .HasMany(p => p.OrderDetails)
            .WithOne(od => od.Product)
            .HasForeignKey(od => od.ProductId);
    }
}