using Backend.Configuration;
using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Services.UserServices
{
    public class ProfileService : Service<Profile>
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileService() : base((IProfileRepository)Injector.GetRepositoryInstance("IProfileRepository"))
        {
            _profileRepository = (IProfileRepository)Injector.GetRepositoryInstance("IProfileRepository");
        }

        public Profile GetByUsernameAndPassword(string username, string password)
        {
            return _profileRepository.GetByUsernameAndPassword(username, password);
        }

        public bool DoesUsernameExist(string username)
        {
            return _profileRepository.DoesUsernameExist(username);
        }
    }
}
