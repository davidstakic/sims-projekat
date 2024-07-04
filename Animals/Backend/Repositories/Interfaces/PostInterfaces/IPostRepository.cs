using Backend.Models.PostModels;

namespace Backend.Repositories.Interfaces.PostInterfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetPostByAnimalId(int animalId);
    }
}
