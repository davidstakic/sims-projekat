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
    }
}
