using Backend.Models.VoteModels;

namespace Backend.Repositories.Interface.IRepositoryVoteModels
{
    public interface IVoteRepository : IRepository<Vote>
    {
        IEnumerable<Vote> GetVoteByVolunteerId(int volunteerId);
        IEnumerable<Vote> GetVoteByVotingId(int votingId);
    }
}
