namespace IRepositories;
public interface IContextRepository<TEntity> where TEntity : class
{
    public Task<int> SaveAsync(); 
    protected DbContext Context { get; }
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> FindLastAsync(Expression<Func<TEntity, bool>> expression);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task RemoveAsync(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);

    Task UpdateAsync(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
}
