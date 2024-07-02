using Backend.Configuration;
using Backend.Models.PostModels;
using Backend.Repositories.Interfaces.PostInterfaces;

namespace Backend.Services.PostServices
{
    public class CommentService : Service<Comment>
    {
        public CommentService() : base((ICommentRepository)Injector.GetRepositoryInstance("ICommentRepository"))
        {
        }
    }
}
