using Backend.Models.AnimalModels;
using Backend.Models.PostModels;
using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Frontend.View;
using System.Windows.Input;

public class PostDetailViewModel : ObservableObject
{
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
    public PostDetailView PostDetailView { get; set; }
    private PostService _postService { get; set; }
    private LikeService _likeService { get; set; }
    private CommentService _commentService { get; set; }
    private AnimalService _animalService { get; set; }
    private SpecieService _specieService { get; set; }
    public ICommand LikeCommand { get; }
    public ICommand CommentCommand { get; }
    public ICommand OptionsCommand { get; }

    public PostDetailViewModel(Post post, Member member, Animal animal, string specieName, int likeCount, int commentCount, PostService postService, LikeService likeService, CommentService commentService, AnimalService animalService, SpecieService specieService)
    {
        Post = post;
        Member = member;
        FirstName = member.FirstName;
        LastName = member.LastName;
        Animal = animal;
        SpecieName = specieName;
        LikeCount = likeCount;
        CommentCount = commentCount;
        _postService = postService;
        _likeService = likeService;
        _commentService = commentService;
        _animalService = animalService;
        _specieService = specieService;

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
        new OptionsView(Member.Id, Post.Id, _postService, _likeService, _commentService, _animalService, _specieService, PostDetailView).ShowDialog();
    }
}
