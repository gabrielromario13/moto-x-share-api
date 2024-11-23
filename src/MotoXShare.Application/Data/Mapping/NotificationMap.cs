using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Application.Domain.Model;

namespace MotoXShare.Application.Data.Mapping;

public class NotificationMap : IEntityTypeConfiguration<DeliveryRiderNotification>
{
    public void Configure(EntityTypeBuilder<DeliveryRiderNotification> builder)
    {
        builder.ToTable("Notification");

        builder.HasKey(x => x.Id);
        builder.Property(b => b.OrderId).IsRequired();
        builder.Property(b => b.DeliveryRidersIds).IsRequired();
    }
}