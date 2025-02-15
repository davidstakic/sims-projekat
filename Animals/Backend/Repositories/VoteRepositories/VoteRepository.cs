﻿using Backend.Models.VoteModels;
using Backend.Repositories.Interfaces.VoteInterfaces;

namespace Backend.Repositories.VoteRepositories
{
    public class VoteRepository : Repository<Vote>, IVoteRepository
    {
        public VoteRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<Vote> IVoteRepository.GetVoteByVolunteerId(int volunteerId)
        {
            return GetAll().Where(m => m.VolunteerId == volunteerId);
        }
        IEnumerable<Vote> IVoteRepository.GetVoteByVotingId(int votingId)
        {
            return GetAll().Where(m => m.VotingId == votingId);
        }
    }
}
