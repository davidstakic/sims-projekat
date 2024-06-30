using Backend.Models.VoteModels;

namespace Backend.Repositories.Interface.IRepositoryVoteModels
{
    public interface IVotingRepository : IRepository<Voting>
    {
        IEnumerable<Voting> GetVotingByMemberId(int memberId);
    }
}
