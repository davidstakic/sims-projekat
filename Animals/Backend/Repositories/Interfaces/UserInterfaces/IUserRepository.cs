using Backend.Models.UserModels;

namespace Backend.Repositories.Interfaces.UserInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByProfileId(int profileId);
        User GetUserByAssociationId(int associationId);
    }
}
