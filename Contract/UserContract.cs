using OrmModel.OpenIddictApiServer;

namespace Repositories;
public class UserContract : Transaction, IUserContract<IUserRepository<User>>
{
    public UserContract(DbContext context) : base(context)
    {
    }
}
