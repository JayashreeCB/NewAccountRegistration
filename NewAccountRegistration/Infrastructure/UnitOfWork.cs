using Microsoft.EntityFrameworkCore;
using NewAccountRegistration.Interface;
using NewAccountRegistration.Models;
using NewAccountRegistration.Repository;

namespace NewAccountRegistration.Infrastructure
{
    public class UnitOfWork : IRepository, IUnitOfWork
    {
        private readonly Cspusermgmtdb01Context _context;
        private bool _disposed = false;
        private IUserRepository _userRepository;
        private readonly IConfiguration _configuration;



        public UnitOfWork(IConfiguration configuration,  Cspusermgmtdb01Context dbContext)
        {
            _configuration = configuration ?? throw new ArgumentException(nameof(configuration));
            _context = dbContext ?? throw new ArgumentException(nameof(dbContext));
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_configuration, _context);

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed) { return; }

            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
