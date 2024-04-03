using MotoXShare.Domain.Base;
using System.Linq.Expressions;

namespace MotoXShare.Infraestructure.Data.Repository.Interface;

public interface IRepositoryAsync<T> where T : BaseEntity
{
    Task Add(T aggregateRoot);
    Task Update(T aggregateRoot);
    Task Remove(T aggregateRoot);
    Task<T> GetById(Guid id);
    Task<T> GetSingle(Expression<Func<T, bool>> predicate = default, IEnumerable<Expression<Func<T, object>>> includeProperties = default);
    Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate = default, IEnumerable<Expression<Func<T, object>>> includeProperties = default);
}