using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Domain.Model;

namespace MotoXShare.Infraestructure.Data.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);
        builder.Property(b => b.FullName).IsRequired();
        builder.Property(b => b.Username).IsRequired();
        builder.Property(b => b.Email).IsRequired();
        builder.Property(b => b.Password).IsRequired();
        builder.Property(b => b.Role).IsRequired();
    }
}