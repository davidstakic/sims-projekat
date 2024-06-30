using Backend.Models.UserModels;
using Backend.Repositories.Interface;

namespace Backend.Repositories.Interface.IRepositoryUser
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetUserByProfileId(int profileId);
        IEnumerable<User> GetUserByAssociationId(int associationId);
    }
}
