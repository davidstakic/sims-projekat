using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Repositories.UserRepositories
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(string filePath) : base(filePath)
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
