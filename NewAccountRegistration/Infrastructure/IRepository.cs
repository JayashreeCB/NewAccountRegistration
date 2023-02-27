using NewAccountRegistration.Interface;

namespace NewAccountRegistration.Infrastructure
{
    public interface IRepository
    {
        IUserRepository UserRepository { get; }
    }
}
