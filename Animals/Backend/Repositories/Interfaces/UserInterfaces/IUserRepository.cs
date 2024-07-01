using Backend.Models.UserModels;

namespace Backend.Repositories.Interfaces.UserInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetUserByProfileId(int profileId);
        IEnumerable<User> GetUserByAssociationId(int associationId);
    }
}
