using Backend.Configuration;
using Backend.Models.VoteModels;
using Backend.Repositories.Interfaces.VoteInterfaces;

namespace Backend.Services.VoteServices
{
    public class VoteService : Service<Vote>
    {
        private readonly IVoteRepository _voteRepository;
        public VoteService() : base((IVoteRepository)Injector.GetRepositoryInstance("IVoteRepository"))
        {
            _voteRepository = (IVoteRepository)Injector.GetRepositoryInstance("IVoteRepository");
        }
    }
}
