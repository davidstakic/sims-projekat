using Backend.Models.PostModels;
using Backend.Models.AnimalModels;

public class PostViewModel
{
    public Post Post { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Animal Animal { get; set; }
    public int LikeCount { get; set; }
    public string SpecieName { get; set; }
    public int CommentCount { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public PostViewModel(Post post, string firstName, string lastName, Animal animal, string specieName, int likeCount, int commentCount)
    {
        Post = post;
        FirstName = firstName;
        LastName = lastName;
        Animal = animal;
        SpecieName = specieName;
        LikeCount = likeCount;
        CommentCount = commentCount;
    }
}