using Backend.Models.PostModels;
using Backend.Repositories.Interfaces.PostInterfaces;

namespace Backend.Repositories.PostRepositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<Comment> ICommentRepository.GetCommentByPostId(int postId)
        {
            return GetAll().Where(m => m.PostId == postId);
        }
    }
}
