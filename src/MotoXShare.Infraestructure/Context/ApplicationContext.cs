using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MotoXShare.Infraestructure.Data.Mapping.Base;

namespace MotoXShare.Infraestructure.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options, bool applyMigration = default) : base(options)
    {
        if (Database.IsRelational() && applyMigration)
            Database.Migrate();
    }

    public ApplicationContext() : base()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Path.GetFullPath("..\\MotoXShare.API"))
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityFrameworkEntrypoint).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}