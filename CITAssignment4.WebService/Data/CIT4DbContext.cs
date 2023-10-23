using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CITAssignment4.DataLayer.Domain;

public class CIT4DbContext : DbContext
{
    public CIT4DbContext(DbContextOptions<CIT4DbContext> options)
        : base(options)
    {
    }

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

    public DbSet<CITAssignment4.DataLayer.Domain.Category> Category { get; set; } = default!;

    public DbSet<CITAssignment4.DataLayer.Domain.Product> Product { get; set; } = default!;

    public DbSet<CITAssignment4.DataLayer.Domain.Order> Order { get; set; } = default!;

    public DbSet<CITAssignment4.DataLayer.Domain.OrderDetails> OrderDetails { get; set; } = default!;
}
