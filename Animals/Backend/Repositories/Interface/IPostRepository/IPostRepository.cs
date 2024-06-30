using Backend.Models.AnimalModels;
using Backend.Models.PostModels;

namespace Backend.Repositories.Interface.IPostRepository
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetPostByAnimalId(int animalId);
        IEnumerable<Post> GetPostByUserId(int userId);
    }
}
