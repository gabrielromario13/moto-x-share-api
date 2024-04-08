using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Data.Mapping.Base;
using MotoXShare.Domain.Model;

namespace MotoXShare.Data.Mapping;

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