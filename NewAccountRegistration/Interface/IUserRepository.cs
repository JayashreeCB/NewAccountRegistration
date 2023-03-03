using NewAccountRegistration.DataTransferModel;
using NewAccountRegistration.Models;

namespace NewAccountRegistration.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<GetJarvisInfo> GetJarvisInfo(string SingpassID);
        Task<string> UpdateJarvisUser(GetJarvisInfo jarvisInfo);
        Task<GetAddressDto> GetAddress(int Postalcode);
    }
}
