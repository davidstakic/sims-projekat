namespace Backend.Models.VoteModels
{
    public class Voting
    {
        public int Id { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public int MemberId { get; set; }

        public Voting() { }
        public Voting(int id, DateOnly start, DateOnly end, int memberId)
        {
            Id = id;
            Start = start;
            End = end;
            MemberId = memberId;
        }
    }
}
