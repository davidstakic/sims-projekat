using Backend.Models.PostModels;
using Backend.Repositories.Interface.IPostRepository;

namespace Backend.Repositories.PostRepository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<Comment> ICommentRepository.GetCommentByUserId(int userId)
        {
            return GetAll().Where(m => m.UserId == userId);
        }

        IEnumerable<Comment> ICommentRepository.GetCommentByPostId(int postId)
        {
            return GetAll().Where(m => m.PostId == postId);
        }
    }
}
