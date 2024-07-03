﻿using Backend.Models.PostModels;
using Backend.Services.PostServices;
using Frontend.ViewModel.ModelViewModels.PostViewModels;

public class LikesViewModel
{
    public int UserId { get; }
    public int PostId { get; }
    private PostService _postService { get; set; }
    private LikeService _likeService { get; set; }
    public List<LikeViewModel> Likes { get; set; }

    public LikesViewModel(int userId, int postId, PostService postService, LikeService likeService)
    {
        UserId = userId;
        PostId = postId;
        _postService = postService;
        _likeService = likeService;

        Update();
    }


    public void Update()
    {
        List<LikeViewModel> likes = new();

        foreach (Like like in _likeService.GetLikesByPostId(PostId))
        {
            LikeViewModel likeModel = new LikeViewModel(like);
            if (likeModel != null)
                likes.Add(likeModel);
        }

        Likes = likes;
    }
}
