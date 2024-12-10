using SimplyLifestyle.Application;
using SimplyLifestyle.Domain;

namespace SimplyLifestyle.Infrastructure;

public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IAggregateRoot
{
    protected Repository(SimplyLifestyleDbContext dbContext)
        => DbContext = dbContext;

    protected SimplyLifestyleDbContext DbContext { get; init; }

    protected IQueryable<TEntity> All()
        => DbContext.Set<TEntity>();

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        DbContext.Add(entity);

        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        DbContext.AddRange(entities);

        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        DbContext.Update(entity);

        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default)
    {
        DbContext.UpdateRange(entity);

        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        DbContext.Remove(entity);

        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        DbContext.RemoveRange(entities);

        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task ClearAsync(CancellationToken cancellationToken = default)
    {
        var dbSet = DbContext.Set<TEntity>();
        if (dbSet.Any())
        {
            dbSet.RemoveRange(dbSet.ToList());
        }

        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
