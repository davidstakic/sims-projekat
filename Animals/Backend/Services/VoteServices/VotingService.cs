using Backend.Configuration;
using Backend.Models.VoteModels;
using Backend.Repositories.Interfaces.VoteInterfaces;

namespace Backend.Services.VoteServices
{
    public class VotingService : Service<Voting>
    {
        public VotingService() : base((IVotingRepository)Injector.GetRepositoryInstance("IVotingRepository"))
        {
        }
    }
}
