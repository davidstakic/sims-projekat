using Backend.Models.AnimalModels;
using Backend.Models.PostModels;
using Backend.Models.UserModels;
using Backend.Services.PostServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Frontend.View;
using System.Windows.Input;

public class PostDetailViewModel : ObservableObject
{
    private LikeService _likeService = new LikeService();
    private CommentService _commentService = new CommentService();
    public Post Post { get; set; }
    public Member Member { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Animal Animal { get; set; }
    public string SpecieName { get; set; }
    private bool _isLiked;
    public bool IsLiked
    {
        get { return _isLiked; }
        set { SetProperty(ref _isLiked, value); }
    }
    private int _likeCount;
    public int LikeCount
    {
        get { return _likeCount; }
        set { SetProperty(ref _likeCount, value); }
    }
    private int _commentCount;
    public int CommentCount
    {
        get { return _commentCount; }
        set { SetProperty(ref _commentCount, value); }
    }
    public string FullName => $"{FirstName} {LastName}";
    public ICommand LikeCommand { get; }
    public ICommand CommentCommand { get; }
    public ICommand OptionsCommand { get; }

    public PostDetailViewModel(Post post, Member member, Animal animal, string specieName, int likeCount, int commentCount)
    {
        Post = post;
        Member = member;
        FirstName = member.FirstName;
        LastName = member.LastName;
        Animal = animal;
        SpecieName = specieName;
        LikeCount = likeCount;
        CommentCount = commentCount;

        LikeCommand = new RelayCommand(OnLike);
        CommentCommand = new RelayCommand(OnComment);
        OptionsCommand = new RelayCommand(OnOptions);

        IsLiked = _likeService.GetAll().Any(like => like.UserId == Member.Id && like.PostId == Post.Id);
    }

    private void OnLike()
    {
        var hasAlreadyLiked = _likeService.GetAll().Any(like => like.UserId == Member.Id && like.PostId == Post.Id);

        if (!hasAlreadyLiked)
        {
            LikeCount++;
            _likeService.Create(new Like(0, DateTime.Now, Member.Id, Post.Id));
            IsLiked = true;
        }
        else
        {
            LikeCount--;
            Like like = _likeService.GetAll().FirstOrDefault(like => like.UserId == Member.Id && like.PostId == Post.Id)!;
            _likeService.Delete(like.Id);
            IsLiked = false;
        }
    }

    private void OnComment()
    {
        var newCommentViewModel = new CreateCommentViewModel(_commentService, Post, Member);
        var newCommentView = new CreateCommentView(newCommentViewModel);
        newCommentView.ShowDialog();

        CommentCount = _commentService.GetAll().Count(comment => comment.PostId == Post.Id);
    }

    private void OnOptions()
    {
        var optionsMenuViewModel = new OptionsMenuViewModel();
        var optionsMenuView = new OptionsMenuView
        {
            DataContext = optionsMenuViewModel
        };
        optionsMenuView.ShowDialog();
    }
}
