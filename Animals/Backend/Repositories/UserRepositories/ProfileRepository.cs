using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Repositories.UserRepositories
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(string filePath) : base(filePath)
        {
        }
    }
}
