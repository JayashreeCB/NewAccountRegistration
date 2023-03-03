using Dapr.Client;
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
        const string storeName = "statestore";

        private readonly DaprClient _daprClient;        

        public UserService(IRepository repository, IUnitOfWork unitOfWork , DaprClient daprClient)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(unitOfWork));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _daprClient = daprClient;
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

        public async Task<GetAddressDto> GetAddress(int Postalcode)
        {
           var info =  await _repository.UserRepository.GetAddress(Postalcode);
            GetAddressDto address = new GetAddressDto
            {
                PostalCode = info.PostalCode,
                Country =info.Country,
                BlockNumber= info.BlockNumber,
                BuildingName    = info.BuildingName,
                LevelNumber = info.LevelNumber, 
                StreetName= info.StreetName,
                UnitNumber  = info.UnitNumber,
            };

            return address;
        }

        public async Task<string> UpdateJarvisUser(GetJarvisInfo jarvisInfo)
        {
            return await _repository.UserRepository.UpdateJarvisUser(jarvisInfo);
        }       

        public async Task SaveUserStateAsync(GetJarvisInfo jarvisInfo)
        {
            await _daprClient.SaveStateAsync(
                storeName, "test", jarvisInfo);
        }

        public async Task<GetJarvisInfo> GetUserStateAsync(string SingpassID)
        {
            return await _daprClient.GetStateAsync<GetJarvisInfo>(
                storeName, "test");
        }
    }
}
