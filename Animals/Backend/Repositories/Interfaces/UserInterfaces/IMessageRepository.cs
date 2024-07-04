using Backend.Models.UserModels;

namespace Backend.Repositories.Interfaces.UserInterfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> GetMessageBySenderId(int senderId);
        IEnumerable<Message> GetMessageByRecieverId(int recieverId);
    }
}
