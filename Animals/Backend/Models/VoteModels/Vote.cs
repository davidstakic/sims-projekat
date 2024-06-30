namespace Backend.Models.VoteModels
{
    public class Vote
    {
        public int Id { get; set; }
        public DateTime VoteDate { get; set; }
        public string Comment { get; set; }
        public bool IsFor { get; set; }
        public int VolunteerId { get; set; }
        public int VotingId { get; set; }

        public Vote() { }
        public Vote(int id, DateTime votedDate, string comment, bool isFor, int volunteerId, int votingId)
        {
            Id = id;
            VoteDate = votedDate;
            Comment = comment;
            IsFor = isFor;
            VolunteerId = volunteerId;
            VotingId = votingId;
        }
    }
}
