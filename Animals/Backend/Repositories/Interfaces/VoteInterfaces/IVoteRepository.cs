using Backend.Models.VoteModels;

namespace Backend.Repositories.Interfaces.VoteInterfaces
{
    public interface IVoteRepository : IRepository<Vote>
    {
        IEnumerable<Vote> GetVoteByVolunteerId(int volunteerId);
        IEnumerable<Vote> GetVoteByVotingId(int votingId);
    }
}
