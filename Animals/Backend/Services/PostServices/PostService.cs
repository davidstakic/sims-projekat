using Backend.Configuration;
using Backend.Models.PostModels;
using Backend.Repositories.Interfaces.PostInterfaces;

namespace Backend.Services.PostServices
{
    public class PostService : Service<Post>
    {
        public PostService() : base((IPostRepository)Injector.GetRepositoryInstance("IPostRepository"))
        {
        }

        public List<Post> GetPostByAnimalId(int animalId)
        {
            return GetAll().Where(m => m.AnimalId == animalId).ToList();
        }

        public List<Post> GetPostByUserId(int userId)
        {
            return GetAll().Where(m => m.UserId == userId).ToList();
        }
    }
}
