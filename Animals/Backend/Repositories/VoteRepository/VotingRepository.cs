using Backend.Models.VoteModels;
using Backend.Repositories.Interface.IRepositoryVoteModels;

namespace Backend.Repositories.VoteRepository.VoteRepository
{
    public class VotingRepository : Repository<Voting>, IVotingRepository
    {
        public VotingRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<Voting> IVotingRepository.GetVotingByMemberId(int memberId)
        {
            return GetAll().Where(m => m.MemberId == memberId);
        }
    }
}
