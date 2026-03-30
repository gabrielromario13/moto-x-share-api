using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MotoXShare.Core.Domain.Entities;

namespace MotoXShare.Core.Data.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public AppDbContext() { }

    public DbSet<DeliveryRider> DeliveryRiders { get; set; } = null!;
    public DbSet<DeliveryRiderNotification> DeliveryRiderNotifications { get; set; } = null!;
    public DbSet<Motorcycle> Motorcycles { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Rental> Rentals { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.GetFullPath("..\\MotoXShare.API"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}