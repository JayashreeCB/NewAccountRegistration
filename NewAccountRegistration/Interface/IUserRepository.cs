using NewAccountRegistration.Models;

namespace NewAccountRegistration.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
    }
}
