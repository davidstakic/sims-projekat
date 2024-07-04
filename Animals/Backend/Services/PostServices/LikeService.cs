using Backend.Configuration;
using Backend.Models.PostModels;
using Backend.Repositories.Interfaces.PostInterfaces;

namespace Backend.Services.PostServices
{
    public class LikeService : Service<Like>
    {
        private readonly ILikeRepository _likeRepository;
        public LikeService() : base((ILikeRepository)Injector.GetRepositoryInstance("ILikeRepository"))
        {
            _likeRepository = (ILikeRepository)Injector.GetRepositoryInstance("ILikeRepository");
        }

        public List<Like> GetLikeByPostId(int postId)
        {
            return _likeRepository.GetLikeByPostId(postId).ToList();
        }
    }
}
