using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Domain.Model;
using MotoXShare.Infraestructure.Data.Mapping.Base;

namespace MotoXShare.Infraestructure.Data.Mapping;

public class UserMap : EntityBaseConfiguration<User>
{
    public override void ConfigureMapping(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.Property(b => b.FullName).IsRequired();
        builder.Property(b => b.Username).IsRequired();
        builder.Property(b => b.Email).IsRequired();
        builder.Property(b => b.Password).IsRequired();
        builder.Property(b => b.Role).IsRequired();
    }
}