namespace NewAccountRegistration.Infrastructure
{
    public interface IUnitOfWork : IRepository, IDisposable
    {
        Task<int> CommitAsync();

        int Commit();
    }
}
