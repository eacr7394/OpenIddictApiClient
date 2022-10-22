namespace IContract;
public interface ITransaction : IDisposable
{
    Task CommitAsync();

    Task RollbackAsync();

    Task DisposeAsync();
}
