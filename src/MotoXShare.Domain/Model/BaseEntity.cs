namespace MotoXShare.Domain.Base;

public abstract class BaseEntity
{
    public virtual Guid Id { get; protected set; }

    protected BaseEntity(Guid id)
    {
        SetId(id);
    }

    protected BaseEntity()
    {
        SetId(Guid.Empty);
    }

    private void SetId(Guid id)
    {
        Id = id == Guid.Empty
            ? Guid.NewGuid()
            : id;
    }
}