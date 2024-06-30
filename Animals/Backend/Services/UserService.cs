using Backend.Models.UserModels;
using Backend.Repositories.Interface;
using Backend.Utils;

namespace Backend.Services
{
    public class UserService : Service<User>
    {
        public UserService() : base((IRepository<User>)Injector.GetRepositoryInstance("IUserRepository"))
        {
        }
    }
}
