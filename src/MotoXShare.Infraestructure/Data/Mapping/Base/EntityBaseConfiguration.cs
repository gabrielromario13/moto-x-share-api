using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoXShare.Domain.Base;

namespace MotoXShare.Infraestructure.Data.Mapping.Base;

public abstract class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(c => c.Id);
    }

    public abstract void ConfigureMapping(EntityTypeBuilder<T> builder);
}