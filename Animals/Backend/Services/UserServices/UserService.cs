using Backend.Configuration;
using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Services.UserServices
{
    public class UserService : Service<User>
    {
        private readonly IUserRepository _userRepository;

        public UserService() : base((IUserRepository)Injector.GetRepositoryInstance("IUserRepository"))
        {
            _userRepository = (IUserRepository)base._repository;
        }

        public User GetUserByProfileId(int profileId)
        {
            return _userRepository.GetUserByProfileId(profileId);
        }
    }
}