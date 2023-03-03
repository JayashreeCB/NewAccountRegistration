using NewAccountRegistration.DataTransferModel;
using NewAccountRegistration.Models;

namespace NewAccountRegistration.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetUserDetails();
        Task<GetJarvisInfo> GetJarvisUser(String SingpassID);

        Task<string> UpdateJarvisUser(GetJarvisInfo jarvisInfo);
        Task SaveUserStateAsync(GetJarvisInfo jarvisInfo);
        Task<GetJarvisInfo> GetUserStateAsync(string SingpassID);
    }
}
