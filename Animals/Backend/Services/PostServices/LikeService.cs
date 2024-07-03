using Backend.Configuration;
using Backend.Models.PostModels;
using Backend.Repositories.Interfaces.PostInterfaces;

namespace Backend.Services.PostServices
{
    public class LikeService : Service<Like>
    {
        public LikeService() : base((ILikeRepository)Injector.GetRepositoryInstance("ILikeRepository"))
        {
        }

        public List<Like> GetLikeByUserId(int userId)
        {
            return GetAll().Where(m => m.UserId == userId).ToList();
        }

        public List<Like> GetLikeByPostId(int postId)
        {
            return GetAll().Where(m => m.PostId == postId).ToList();
        }
    }
}
