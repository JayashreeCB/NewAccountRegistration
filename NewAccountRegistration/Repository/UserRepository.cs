using Microsoft.EntityFrameworkCore;
using NewAccountRegistration.Interface;
using NewAccountRegistration.Models;

namespace NewAccountRegistration.Repository
{
    public class UserRepository :IUserRepository
    {
        private readonly Cspusermgmtdb01Context _context;
        public UserRepository( Cspusermgmtdb01Context cspusermgmtdb01Context)
        {
            _context = cspusermgmtdb01Context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync<User>();
        }
    }
}
