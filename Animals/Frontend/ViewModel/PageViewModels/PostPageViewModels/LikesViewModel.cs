using Backend.Models.PostModels;
using Backend.Services.PostServices;
using Frontend.ViewModel.ModelViewModels.PostViewModels;

public class LikesViewModel
{
    private LikeService _likeService;
    
    public int UserId { get; }
    public int PostId { get; }
    public List<LikeViewModel> Likes { get; set; }

    public LikesViewModel(int userId, int postId, LikeService likeService)
    {
        UserId = userId;
        PostId = postId;
        _likeService = likeService;

        Update();
    }

    public void Update()
    {
        List<LikeViewModel> likes = new();

        foreach (Like like in _likeService.GetLikeByPostId(PostId))
        {
            LikeViewModel likeModel = new LikeViewModel(like);
            if (likeModel != null)
                likes.Add(likeModel);
        }

        Likes = likes;
    }
}
