namespace IRepositories;
public interface IUserRepository<TEntity> : IContextRepository<TEntity> where TEntity : class
{
}
