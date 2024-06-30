namespace Backend.Models.PostModels
{
    public class Like
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public Like() { }
        public Like(int id, DateTime date, int userId, int postId)
        {
            Id = id;
            Date = date;
            UserId = userId;
            PostId = postId;
        }
    }
}
