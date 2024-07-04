using Backend.Configuration;
using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Services.UserServices
{
    public class ProfileService : Service<Profile>
    {
        public ProfileService() : base((IProfileRepository)Injector.GetRepositoryInstance("IProfileRepository"))
        {
        }

        public Profile GetByUsernameAndPassword(string username, string password)
        {
            return GetAll().FirstOrDefault(p => p.Username == username && p.Password == password)!;
        }

        public bool DoesUsernameExist(string username)
        {
            return GetAll().Any(p => p.Username == username);
        }
    }
}
