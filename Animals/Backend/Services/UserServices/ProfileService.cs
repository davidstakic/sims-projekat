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
    }
}
