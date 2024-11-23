using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MotoXShare.Application.Domain.Model;

namespace MotoXShare.Application.Features.Common;

public class RepositoryAsync<T>
    : IRepositoryAsync<T> where T : BaseEntity
{
    protected readonly DbSet<T> DbSet;

    protected RepositoryAsync(DbContext context)
    {
        DbSet = context.Set<T>();
    }

    public async Task Add(T aggregateRoot)
    {
        await DbSet.AddAsync(aggregateRoot);
    }

    public Task Update(T aggregateRoot)
    {
        DbSet.Update(aggregateRoot);
        return Task.CompletedTask;
    }

    public async Task Remove(T aggregateRoot)
    {
        var result = await DbSet.FirstOrDefaultAsync(c => c.Id == aggregateRoot.Id);

        if (result is not null)
            DbSet.Remove(result);
    }

    public async Task<T> GetById(Guid id) =>
        await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<T> GetSingle(
        Expression<Func<T, bool>> predicate = null,
        IEnumerable<Expression<Func<T, object>>> includeProperties = default)
    {
        var query = DbSet.AsNoTracking();

        if (predicate is not null)
            query = query.Where(predicate);

        if (includeProperties is null)
            return await query.FirstOrDefaultAsync();
        
        query = includeProperties.Aggregate(query, 
            (current, property) => current.Include(property));

        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> Get(
        Expression<Func<T, bool>> predicate = null,
        IEnumerable<Expression<Func<T, object>>> includeProperties = default)
    {
        var query = DbSet.AsNoTracking()
                          .AsQueryable();

        if (predicate is not null)
            query = query.Where(predicate);

        if (includeProperties is null)
            return await query.ToListAsync();
        
        query = includeProperties.Aggregate(query,
            (current, property) => current.Include(property));

        return await query.ToListAsync();
    }
}