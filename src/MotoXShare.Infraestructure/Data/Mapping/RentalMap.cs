using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Domain.Enums;
using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Data.Mapping.Base;

namespace MotoXShare.Infraestructure.Data.Mapping;

public class RentalMap : EntityBaseConfiguration<Rental>
{
    public override void ConfigureMapping(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable("Rental");

        builder.Property(b => b.Plan).HasConversion(typeof(RentalPlans)).IsRequired();
        builder.Property(b => b.StartDate).HasDefaultValue(DateTime.Now.AddDays(1)).IsRequired();
        builder.Property(b => b.EndDatePrevision).IsRequired();
        builder.Property(b => b.EndDate).IsRequired();
        builder.Property(b => b.Active).HasDefaultValue(true);

        builder
            .HasOne(x => x.DeliveryRider)
            .WithOne()
            .IsRequired();

        builder
            .HasOne(x => x.Motorcycle)
            .WithOne()
            .IsRequired();
    }
}