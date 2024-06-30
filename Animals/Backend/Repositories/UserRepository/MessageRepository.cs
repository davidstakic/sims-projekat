using Backend.Models.UserModels;
using Backend.Repositories.Interface.IUserRepository;

namespace Backend.Repositories.UserRepository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<Message> IMessageRepository.GetMessageBySenderId(int senderId)
        {
            return GetAll().Where(m => m.SenderId == senderId);
        }

        IEnumerable<Message> IMessageRepository.GetMessageByRecieverId(int recieverId)
        {
            return GetAll().Where(m => m.RecieverId == recieverId);
        }
    }
}
