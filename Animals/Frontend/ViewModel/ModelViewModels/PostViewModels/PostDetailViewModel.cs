using Backend.Models.AnimalModels;
using Backend.Models.PostModels;
using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Frontend.View;
using System.Windows.Input;

public class PostDetailViewModel : ObservableObject
{
    private bool _isLiked;
    private int _likeCount;
    private int _commentCount;
    private PostService _postService;
    private LikeService _likeService;
    private CommentService _commentService;
    private AnimalService _animalService;
    private SpecieService _specieService;
    private AdoptionService _adoptionService;
    private DonationService _donationService;
    private MemberService _memberService;
    private VolunteerService _volunteerService;
    private User _postMaker;

    public User CurrentUser { get; set; }
    public Post Post { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Animal Animal { get; set; }
    public string SpecieName { get; set; }
    public bool IsLiked
    {
        get { return _isLiked; }
        set { SetProperty(ref _isLiked, value); }
    }
    public int LikeCount
    {
        get { return _likeCount; }
        set { SetProperty(ref _likeCount, value); }
    }
    public int CommentCount
    {
        get { return _commentCount; }
        set { SetProperty(ref _commentCount, value); }
    }
    public string FullName => $"{FirstName} {LastName}";
    public PostDetailView PostDetailView { get; set; }
    public ICommand LikeCommand { get; }
    public ICommand CommentCommand { get; }
    public ICommand OptionsCommand { get; }

    public PostDetailViewModel(User currentUser, Post post, Animal animal, string specieName, int likeCount, int commentCount, PostService postService, LikeService likeService, CommentService commentService, AnimalService animalService, SpecieService specieService, AdoptionService adoptionService, DonationService donationService, MemberService memberService, VolunteerService volunteerService)
    {
        CurrentUser = currentUser;
        Post = post;

        _memberService = memberService;
        _volunteerService = volunteerService;
        _postMaker = GetUser(post.UserId);
        FirstName = _postMaker.FirstName;
        LastName = _postMaker.LastName;
        Animal = animal;
        SpecieName = specieName;
        LikeCount = likeCount;
        CommentCount = commentCount;
        _postService = postService;
        _likeService = likeService;
        _commentService = commentService;
        _animalService = animalService;
        _specieService = specieService;
        _adoptionService = adoptionService;
        _donationService = donationService;

        LikeCommand = new RelayCommand(OnLike);
        CommentCommand = new RelayCommand(OnComment);
        OptionsCommand = new RelayCommand(OnOptions);

        IsLiked = _likeService.GetAll().Any(like => like.UserId == CurrentUser.Id && like.PostId == Post.Id);
    }

    private User GetUser(int userId)
    {
        User user = _memberService.GetById(userId);
        if (user == null)
        {
            return _volunteerService.GetById(userId);
        }
        return user;
    }

    private void OnLike()
    {
        var hasAlreadyLiked = _likeService.GetAll().Any(like => like.UserId == CurrentUser.Id && like.PostId == Post.Id);

        if (!hasAlreadyLiked)
        {
            LikeCount++;
            _likeService.Create(new Like(0, DateTime.Now, CurrentUser.Id, Post.Id));
            IsLiked = true;
        }
        else
        {
            LikeCount--;
            Like like = _likeService.GetAll().FirstOrDefault(like => like.UserId == CurrentUser.Id && like.PostId == Post.Id)!;
            _likeService.Delete(like.Id);
            IsLiked = false;
        }
    }

    private void OnComment()
    {
        var newCommentViewModel = new CreateCommentViewModel(_commentService, Post, CurrentUser);
        var newCommentView = new CreateCommentView(newCommentViewModel);
        newCommentView.ShowDialog();

        CommentCount = _commentService.GetAll().Count(comment => comment.PostId == Post.Id);
    }

    private void OnOptions()
    {
        new OptionsView(_postMaker.Id, Post.Id, _postService, _likeService, _commentService, _animalService, _specieService, _adoptionService, _donationService, PostDetailView).ShowDialog();
    }
}
