namespace MotoXShare.Domain.Base;

public abstract class BaseEntity
{
    public virtual Guid Id { get; protected set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}