using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Application.Domain.Model;

namespace MotoXShare.Application.Data.Mapping;

public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");

        builder.HasKey(x => x.Id);
        builder.Property(b => b.DeliveryPrice).IsRequired();
        builder.Property(b => b.Status).IsRequired();
        builder.Property(b => b.CreatedAt).IsRequired();
    }
}