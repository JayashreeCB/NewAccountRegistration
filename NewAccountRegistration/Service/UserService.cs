using NewAccountRegistration.DataTransferModel;
using NewAccountRegistration.Infrastructure;
using NewAccountRegistration.Interface;
using NewAccountRegistration.Models;

namespace NewAccountRegistration.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(unitOfWork));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<GetJarvisInfo> GetJarvisUser(string SingpassID)
        {            
            return await _repository.UserRepository.GetJarvisInfo(SingpassID);            
        }

        public async Task<IEnumerable<GetUserDto>> GetUserDetails()
        {
            var userDetails = await _repository.UserRepository.GetUsers();

            return userDetails.Select(user => new GetUserDto { FirstName = user.FirstName, LastName = user.LastName });
        }

        public async Task<string> UpdateJarvisUser(GetJarvisInfo jarvisInfo)
        {
            return await _repository.UserRepository.UpdateJarvisUser(jarvisInfo);
        }
    }
}
