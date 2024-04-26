using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Domain.Model;

namespace MotoXShare.Infraestructure.Data.Mapping;

public class DeliveryRiderMap : IEntityTypeConfiguration<DeliveryRider>
{
    public void Configure(EntityTypeBuilder<DeliveryRider> builder)
    {
        builder.ToTable("DeliveryRider");

        builder.HasKey(x => x.Id);
        builder.Property(b => b.FullName).IsRequired();
        builder.Property(b => b.BirthDate).IsRequired();
        builder.Property(b => b.CNPJ).IsRequired();
        builder.Property(b => b.CNH).IsRequired();
        builder.Property(b => b.CNHType).IsRequired();
        builder.Property(b => b.CNHImage).IsRequired();
    }
}