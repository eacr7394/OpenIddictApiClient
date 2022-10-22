namespace IContract;
public interface IUserContract<TUserRepository> : ITransaction
    where TUserRepository : IUserRepository<User>
{
}
