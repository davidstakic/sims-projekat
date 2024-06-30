using Backend.Models.UserModels;
using Backend.Repositories.Interface;

namespace Backend.Repositories.Interface.IRepositoryUser
{
    public interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> GetMessageBySenderId(int senderId);
        IEnumerable<Message> GetMessageByRecieverId(int recieverId);
    }
}
