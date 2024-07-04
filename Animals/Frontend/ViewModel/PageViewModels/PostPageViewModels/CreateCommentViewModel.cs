using Backend.Models.PostModels;
using Backend.Models.UserModels;
using Backend.Services.PostServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

public class CreateCommentViewModel : ObservableObject
{
    private readonly Post _post;
    private readonly User _currentUser;
    private readonly CommentService _commentService;

    public string CommentText { get; set; }
    public ICommand SubmitCommentCommand { get; }

    public CreateCommentViewModel(CommentService commentService, Post post, User currentUser)
    {
        _post = post;
        _currentUser = currentUser;
        _commentService = commentService;

        SubmitCommentCommand = new RelayCommand(OnSubmitComment);
    }

    private void OnSubmitComment()
    {
        if (!string.IsNullOrWhiteSpace(CommentText))
        {
            var newComment = new Comment
            {
                Date = DateTime.Now,
                Content = CommentText,
                UserId = _currentUser.Id,
                PostId = _post.Id,
            };

            _commentService.Create(newComment);
            CommentText = string.Empty;
        }
    }
}
