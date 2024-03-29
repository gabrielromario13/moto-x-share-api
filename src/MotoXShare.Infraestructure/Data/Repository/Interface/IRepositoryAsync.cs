using MotoXShare.Domain.Model;
using System.Linq.Expressions;

namespace MotoXShare.Infraestructure.Data.Repository.Interface;

public interface IRepositoryAsync<T> where T : BaseEntity
{
    Task Add(T aggregateRoot);
    Task Update(T aggregateRoot);
    Task Remove(T aggregateRoot);
    Task<T> GetSingle(Expression<Func<T, bool>> predicate = default);
    Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate = default);
}