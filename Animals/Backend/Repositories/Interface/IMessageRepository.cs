using Backend.Models.UserModels;
using Backend.Repositories.Interface;

namespace Backend.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> GetMessageBySenderId(int senderId);
        IEnumerable<Message> GetMessageByRecieverId(int recieverId);
    }
}
