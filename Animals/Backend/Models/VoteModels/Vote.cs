namespace Backend.Models.VoteModels
{
    public class Vote
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool IsFor { get; set; }
        public int VolunteerId { get; set; }
        public int VotingId { get; set; }

        public Vote() { }
        public Vote(int id, DateTime date, string comment, bool isFor, int volunteerId, int votingId)
        {
            Id = id;
            Date = date;
            Comment = comment;
            IsFor = isFor;
            VolunteerId = volunteerId;
            VotingId = votingId;
        }
    }
}
