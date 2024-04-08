using MotoXShare.Domain.Base;
using System.Linq.Expressions;

namespace MotoXShare.Data.Repository.Base;

public interface IRepositoryAsync<T> where T : BaseEntity
{
    Task Add(T aggregateRoot);
    Task Update(T aggregateRoot);
    Task Remove(T aggregateRoot);
    Task<T> GetSingle(Expression<Func<T, bool>> predicate = default);
    Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate = default);
}