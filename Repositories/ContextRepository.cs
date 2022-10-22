namespace Repositories;
public class ContextRepository<TEntity> : IContextRepository<TEntity>
    where TEntity : class
{
    public ContextRepository(DbContext context)
    {
        Context = context;
    }
    protected DbContext Context { get; }
    DbContext IContextRepository< TEntity>.Context => Context;
    public async Task AddAsync(TEntity entity) => await (await Context.AddAsync(entity)).ReloadAsync();
    public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await Context.AddRangeAsync(entities);
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression) => await Context.Set<TEntity>().AnyAsync(expression);
    public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression) => await Context.Set<TEntity>().Where(expression).ToListAsync();
    public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> expression) => await Context.Set<TEntity>().SingleAsync(expression);
    public async Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> expression) => await Context.Set<TEntity>().FirstAsync(expression);
    public async Task<TEntity> FindLastAsync(Expression<Func<TEntity, bool>> expression) => await Context.Set<TEntity>().LastAsync(expression);
    public async Task<List<TEntity>> GetAllAsync() => await Context.Set<TEntity>().ToListAsync();
    public async Task RemoveAsync(TEntity entity) => await Context.Set<TEntity>().Remove(entity).ReloadAsync();
    public void RemoveRange(IEnumerable<TEntity> entities) => Context.Set<TEntity>().RemoveRange(entities);
    public async Task<int> SaveAsync() => await Context.SaveChangesAsync();
    public async Task UpdateAsync(TEntity entity) => await Context.Set<TEntity>().Update(entity).ReloadAsync();
    public void UpdateRange(IEnumerable<TEntity> entities) => Context.Set<TEntity>().UpdateRange(entities);
}
