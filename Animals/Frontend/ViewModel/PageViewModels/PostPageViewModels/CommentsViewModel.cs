using Backend.Models.PostModels;
using Backend.Services.PostServices;

namespace Frontend.ViewModel.ModelViewModels.PostViewModels
{
    public class CommentsViewModel
    {
        private CommentService _commentService;

        public int UserId { get; }
        public int PostId { get; }
        public List<CommentViewModel> Comments { get; set; }

        public CommentsViewModel(int userId, int postId, CommentService commentService)
        {
            UserId = userId;
            PostId = postId;
            _commentService = commentService;

            Update();
        }

        public void Update()
        {
            List<CommentViewModel> comments = new();

            foreach (Comment comment in _commentService.GetCommentByPostId(PostId))
            {
                CommentViewModel commentModel = new CommentViewModel(comment);
                if (commentModel != null)
                    comments.Add(commentModel);
            }

            Comments = comments;
        }
    }
}
