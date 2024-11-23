using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Application.Domain.Model;

namespace MotoXShare.Application.Data.Mapping;

public class MotorcycleMap : IEntityTypeConfiguration<Motorcycle>
{
    public void Configure(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.ToTable("Motorcycle");

        builder.HasKey(x => x.Id);
        builder.Property(b => b.Year).IsRequired();
        builder.Property(b => b.Model).IsRequired();
        builder.Property(b => b.Plate).IsRequired();
        builder.Property(b => b.Rented).IsRequired();
    }
}