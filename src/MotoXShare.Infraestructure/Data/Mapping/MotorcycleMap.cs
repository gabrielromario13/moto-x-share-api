using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Data.Mapping.Base;

namespace MotoXShare.Infraestructure.Data.Mapping;

public class MotorcycleMap : EntityBaseConfiguration<Motorcycle>
{
    public override void ConfigureMapping(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.ToTable("Motorcycle");

        builder.Property(b => b.Year).IsRequired();
        builder.Property(b => b.Model).IsRequired();
        builder.Property(b => b.Plate).IsRequired();
        builder.Property(b => b.Rented).IsRequired();
    }
}