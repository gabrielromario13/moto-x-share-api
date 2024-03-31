using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Data.Mapping.Base;

namespace MotoXShare.Infraestructure.Data.Mapping;

public class OrderMap : EntityBaseConfiguration<Order>
{
    public override void ConfigureMapping(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");

        builder.Property(b => b.DeliveryPrice).HasPrecision(8,2).IsRequired();
        builder.Property(b => b.Status).IsRequired();
        builder.Property(b => b.CreatedAt).IsRequired();
    }
}