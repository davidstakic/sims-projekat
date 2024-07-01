using Backend.Configuration;
using Backend.Models.VoteModels;
using Backend.Repositories.Interfaces.VoteInterfaces;

namespace Backend.Services.VoteServices
{
    public class VoteService : Service<Vote>
    {
        public VoteService() : base((IVoteRepository)Injector.GetRepositoryInstance("IVoteRepository"))
        {
        }
    }
}
