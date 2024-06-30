namespace Backend.Models.PostModels
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public Comment() { }
        public Comment(int id, DateTime date, string content, int userId, int postId)
        {
            Id = id;
            Date = date;
            Content = content;
            UserId = userId;
            PostId = postId;
        }
    }
}
