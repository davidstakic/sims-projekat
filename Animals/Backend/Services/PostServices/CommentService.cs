using Backend.Configuration;
using Backend.Models.PostModels;
using Backend.Repositories.Interfaces.PostInterfaces;

namespace Backend.Services.PostServices
{
    public class CommentService : Service<Comment>
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService() : base((ICommentRepository)Injector.GetRepositoryInstance("ICommentRepository"))
        {
            _commentRepository = (ICommentRepository)Injector.GetRepositoryInstance("ICommentRepository");
        }

        public List<Comment> GetCommentByPostId(int postId)
        {
            return _commentRepository.GetCommentByPostId(postId).ToList();
        }

        public List<Comment> GetCommentByUserId(int userId)
        {
            return _commentRepository.GetCommentByUserId(userId).ToList();
        }
    }
}
