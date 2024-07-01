using Backend.Configuration;
using Backend.Models.PostModels;
using Backend.Repositories.Interfaces.PostInterfaces;

namespace Backend.Services.PostServices
{
    public class CommentSevice : Service<Comment>
    {
        public CommentSevice() : base((ICommentRepository)Injector.GetRepositoryInstance("ICommentRepository"))
        {
        }
    }
}
