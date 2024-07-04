using Backend.Models.UserModels;

namespace Backend.Repositories.Interfaces.UserInterfaces
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Profile GetByUsernameAndPassword(string username, string password);
        bool DoesUsernameExist(string username);
    }
}
