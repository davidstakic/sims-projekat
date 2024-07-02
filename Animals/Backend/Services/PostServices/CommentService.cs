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

        public List<Comment> GetCommentByUserId(int userId)
        {
            return GetAll().Where(m => m.UserId == userId).ToList();
        }

        public List<Comment> GetCommentByPostId(int postId)
        {
            return GetAll().Where(m => m.PostId == postId).ToList();
        }
    }
}
