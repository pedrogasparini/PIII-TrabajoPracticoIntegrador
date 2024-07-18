using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleDetail> SaleDetails { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de las relaciones entre entidades
        modelBuilder.Entity<SaleDetail>()
            .HasKey(sd => new { sd.SaleId, sd.ProductId });

        modelBuilder.Entity<SaleDetail>()
            .HasOne(sd => sd.Sale)
            .WithMany(s => s.SaleDetails)
            .HasForeignKey(sd => sd.SaleId);

        modelBuilder.Entity<SaleDetail>()
            .HasOne(sd => sd.Product)
            .WithMany()
            .HasForeignKey(sd => sd.ProductId);

        // Configuración adicional de entidades si es necesario

        base.OnModelCreating(modelBuilder);
    }
}

