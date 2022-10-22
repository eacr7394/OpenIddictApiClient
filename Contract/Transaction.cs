namespace Repositories;
public class Transaction : ITransaction
{
    private IDbContextTransaction _transaction;

    public Transaction(DbContext context)
    {
        _transaction = context.Database.BeginTransaction();
    }

    public async Task CommitAsync() => await _transaction.CommitAsync();

    public async Task RollbackAsync()=> await _transaction.RollbackAsync();

    public void Dispose()=> _transaction.Dispose();

    public async Task DisposeAsync() => await _transaction.DisposeAsync();
}
