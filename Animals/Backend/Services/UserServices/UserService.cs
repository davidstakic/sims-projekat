using Backend.Configuration;
using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Services.UserServices
{
    public class UserService : Service<User>
    {
        public UserService() : base((IUserRepository)Injector.GetRepositoryInstance("IUserRepository"))
        {
        }
    }
}
