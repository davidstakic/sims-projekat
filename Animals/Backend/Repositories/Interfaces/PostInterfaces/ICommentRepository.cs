using Backend.Models.PostModels;

namespace Backend.Repositories.Interfaces.PostInterfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetCommentByUserId(int userId);
        IEnumerable<Comment> GetCommentByPostId(int postId);
    }
}
