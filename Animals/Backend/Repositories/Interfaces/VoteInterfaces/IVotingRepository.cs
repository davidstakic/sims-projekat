using Backend.Models.VoteModels;

namespace Backend.Repositories.Interfaces.VoteInterfaces
{
    public interface IVotingRepository : IRepository<Voting>
    {
        IEnumerable<Voting> GetVotingByMemberId(int memberId);
    }
}
