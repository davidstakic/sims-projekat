using Backend.Models.PostModels;

public class PostViewModel
{
    public Post Post { get; set; }
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
    public string LikeText => $"Likes: {LikeCount}";
    public string CommentText => $"Comments: {CommentCount}";

    public PostViewModel(Post post, int likeCount, int commentCount)
    {
        Post = post;
        LikeCount = likeCount;
        CommentCount = commentCount;
    }
}
