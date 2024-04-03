using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Data.Mapping.Base;

namespace MotoXShare.Infraestructure.Data.Mapping;

public class NotificationMap : EntityBaseConfiguration<Notification>
{
    public override void ConfigureMapping(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notification");

        builder.Property(b => b.OrderId).IsRequired();
        builder.Property(b => b.DeliveryRidersIds).IsRequired();
    }
}