using Backend.Models.PostModels;

namespace Backend.Repositories.Interface.IPostRepository
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentByUserId(int userId);
        IEnumerable<Comment> GetCommentByPostId(int postId);
    }
}
