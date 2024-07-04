using Backend.Configuration;
using Backend.Models.PostModels;
using Backend.Repositories.Interfaces.PostInterfaces;

namespace Backend.Services.PostServices
{
    public class PostService : Service<Post>
    {
        private readonly IPostRepository _postRepository;
        public PostService() : base((IPostRepository)Injector.GetRepositoryInstance("IPostRepository"))
        {
            _postRepository = (IPostRepository)Injector.GetRepositoryInstance("IPostRepository");
        }

        public List<Post> GetPostsByAnimalId(int animalId)
        {
            return _postRepository.GetPostsByAnimalId(animalId).ToList();
        }
        public Post GetPostByAnimalId(int animalId)
        {
            return _postRepository.GetPostByAnimalId(animalId);
        }

        public List<Post> GetPostByUserId(int userId)
        {
            return _postRepository.GetPostByUserId(userId).ToList();
        }
    }
}
