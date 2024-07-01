using Backend.Models.PostModels;
using Backend.Repositories.Interfaces.PostInterfaces;

namespace Backend.Repositories.PostRepositories
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        public LikeRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<Like> ILikeRepository.GetLikeByUserId(int userId)
        {
            return GetAll().Where(m => m.UserId == userId);
        }

        IEnumerable<Like> ILikeRepository.GetLikeByPostId(int postId)
        {
            return GetAll().Where(m => m.PostId == postId);
        }
    }
}
