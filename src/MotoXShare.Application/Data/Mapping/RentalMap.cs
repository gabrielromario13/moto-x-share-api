using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Application.Domain.Model;

namespace MotoXShare.Application.Data.Mapping;

public class RentalMap : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable("Rental");

        builder.HasKey(x => x.Id);
        builder.Property(b => b.PlanType).IsRequired();
        builder.Property(b => b.StartDate).IsRequired();
        builder.Property(b => b.ExpectedEndDate).IsRequired();
        builder.Property(b => b.RentalPrice).IsRequired();
        builder.Property(b => b.EndDate).IsRequired();
    }
}