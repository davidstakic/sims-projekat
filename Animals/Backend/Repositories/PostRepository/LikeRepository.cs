using Backend.Models.PostModels;
using Backend.Repositories.Interface.IPostRepository;

namespace Backend.Repositories.PostRepository
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
