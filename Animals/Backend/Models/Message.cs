namespace Backend.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime SentDate { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }

        public Message() { }

        public Message(int id, DateTime sentDate, string content, int senderId, int recieverId)
        {
            Id = id;
            SentDate = sentDate;
            Content = content;
            SenderId = senderId;
            RecieverId = recieverId;
        }
    }
}
