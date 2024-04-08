using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Data.Mapping.Base;

namespace MotoXShare.Infraestructure.Data.Mapping;

public class RentalMap : EntityBaseConfiguration<Rental>
{
    public override void ConfigureMapping(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable("Rental");

        builder.Property(b => b.PlanType).IsRequired();
        builder.Property(b => b.StartDate).IsRequired();
        builder.Property(b => b.ExpectedEndDate).IsRequired();
        builder.Property(b => b.EndDate).IsRequired();
        builder.Property(b => b.EndDate).IsRequired();
    }
}