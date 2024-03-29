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

        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.BirthDate).IsRequired();
        builder.Property(b => b.IsAdmin).IsRequired();
    }
}