using Backend.Models.PostModels;

namespace Backend.Repositories.Interfaces.PostInterfaces
{
    public interface ILikeRepository : IRepository<Like>
    {
        IEnumerable<Like> GetLikeByPostId(int postId);
    }
}
