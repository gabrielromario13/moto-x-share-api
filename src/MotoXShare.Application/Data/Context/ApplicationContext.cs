﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MotoXShare.Application.Data.Context;

public sealed class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options, bool applyMigration = default) : base(options)
    {
        if (Database.IsRelational() && applyMigration)
            Database.Migrate();
    }

    public ApplicationContext() { }

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}