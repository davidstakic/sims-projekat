using Backend.Models.PostModels;

namespace Backend.Repositories.Interface.IPostRepository
{
    public interface ILikeRepository
    {
        IEnumerable<Like> GetLikeByUserId(int userId);
        IEnumerable<Like> GetLikeByPostId(int postId);
    }
}
