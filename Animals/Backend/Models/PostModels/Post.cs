using Backend.Models.Enums;

namespace Backend.Models.PostModels
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public Status Status { get; set; }
        public int AnimalId { get; set; }
        public int UserId { get; set; }

        public Post() { }
        public Post(int id, string title, string description, DateTime creationDate, string image, string video, Status status, int animalId, int userId)
        {
            Id = id;
            Title = title;
            Description = description;
            CreationDate = creationDate;
            Image = image;
            Video = video;
            Status = status;
            AnimalId = animalId;
            UserId = userId;
        }
    }
}
