using Microsoft.EntityFrameworkCore;
using MotoXShare.Domain.Base;
using MotoXShare.Infraestructure.Data.Repository.Interface;
using System.Linq.Expressions;

namespace MotoXShare.Infraestructure.Data.Repository;

public class RepositoryAsync<T>
    : IRepositoryAsync<T> where T : BaseEntity
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public RepositoryAsync(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task Add(T aggregateRoot)
    {
        await _dbSet.AddAsync(aggregateRoot);
    }

    public Task Update(T aggregateRoot)
    {
        _dbSet.Update(aggregateRoot);
        return Task.CompletedTask;
    }

    public async Task Remove(T aggregateRoot)
    {
        var result = await _dbSet.FirstOrDefaultAsync(c => c.Id == aggregateRoot.Id);

        if (result is not null)
            _dbSet.Remove(result);
    }

    public async Task<T> GetById(Guid id) =>
        await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<T> GetSingle(
        Expression<Func<T, bool>> predicate = null,
        IEnumerable<Expression<Func<T, object>>> includeProperties = default)
    {
        var query = _dbSet.AsNoTracking();

        if (predicate != null)
            query = query.Where(predicate);

        if (includeProperties != null)
        {
            foreach (var property in includeProperties)
                query = query.Include(property);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> Get(
        Expression<Func<T, bool>> predicate = null,
        IEnumerable<Expression<Func<T, object>>> includeProperties = default)
    {
        var query = _dbSet.AsNoTracking()
                          .AsQueryable();

        if (predicate != null)
            query = query.Where(predicate);

        if (includeProperties != null)
        {
            foreach (var property in includeProperties)
                query = query.Include(property);
        }

        return await query.ToListAsync();
    }
}