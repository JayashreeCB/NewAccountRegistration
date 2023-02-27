using NewAccountRegistration.DataTransferModel;

namespace NewAccountRegistration.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetUserDetails();
    }
}
