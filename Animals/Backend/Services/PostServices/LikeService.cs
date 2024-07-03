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

        public List<Like> GetLikesByPostId(int postId)
        {
            return GetAll().Where(like => like.PostId == postId).ToList();
        }
    }
}
