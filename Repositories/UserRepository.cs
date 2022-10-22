namespace Repositories;
public class UserRepository : ContextRepository<User>, IUserRepository<User>
{ 
    public UserRepository(OpenIddictApiServerContext context) : base(context)
    {
    }

}
