using Backend.Configuration;
using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Services.UserServices
{
    public class MessageService : Service<Message>
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService() : base((IMessageRepository)Injector.GetRepositoryInstance("IMessageRepository"))
        {
            _messageRepository = (IMessageRepository)Injector.GetRepositoryInstance("IMessageRepository");
        }
    }
}
