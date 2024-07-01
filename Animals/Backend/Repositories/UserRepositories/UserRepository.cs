using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Repositories.UserRepositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(string filePath) : base(filePath)
        {
        }

        public User GetUserByProfileId(int profileId)
        {
            return GetAll().FirstOrDefault(m => m.ProfileId == profileId)!;
        }

        public User GetUserByAssociationId(int associationId)
        {
            return GetAll().FirstOrDefault(m => m.AssociationId == associationId)!;
        }
    }
}
