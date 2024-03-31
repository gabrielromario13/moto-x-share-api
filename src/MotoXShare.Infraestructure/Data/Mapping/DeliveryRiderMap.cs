using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Domain.Enums;
using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Data.Mapping.Base;

namespace MotoXShare.Infraestructure.Data.Mapping;

public class DeliveryRiderMap : EntityBaseConfiguration<DeliveryRider>
{
    public override void ConfigureMapping(EntityTypeBuilder<DeliveryRider> builder)
    {
        builder.ToTable("DeliveryRider");

        builder.Property(b => b.CNPJ).IsRequired();
        builder.Property(b => b.CNH).IsRequired(true);
        builder.Property(b => b.CNHType).HasConversion<CnhTypes>().IsRequired();
        builder.Property(b => b.CNHImage).IsRequired();
    }
}