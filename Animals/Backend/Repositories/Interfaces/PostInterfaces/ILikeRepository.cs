using Backend.Models.PostModels;

namespace Backend.Repositories.Interfaces.PostInterfaces
{
    public interface ILikeRepository : IRepository<Like>
    {
        IEnumerable<Like> GetLikeByUserId(int userId);
        IEnumerable<Like> GetLikeByPostId(int postId);
    }
}
