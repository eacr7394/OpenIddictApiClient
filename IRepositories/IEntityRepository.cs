namespace IRepositories;
public interface IEntityRepository<TEntity> : IContextRepository<TEntity>
    where TEntity : class
{
}
