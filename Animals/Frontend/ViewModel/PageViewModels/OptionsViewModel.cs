using Backend.Services.AnimalServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Frontend.View;
using System.Windows.Input;

public class OptionsViewModel : ObservableObject
{
    public ICommand DeletePostCommand { get; }
    public ICommand UpdatePostCommand { get; }
    public ICommand AdoptAnimalCommand { get; }
    public ICommand ShowCommentsCommand { get; }
    public ICommand ShowLikesCommand { get; }
    public int UserId { get; }
    public int PostId { get; }
    public PostDetailView PostDetailView { get; }
    private PostService _postService { get; set; }
    private LikeService _likeService { get; set; }
    private CommentService _commentService { get; set; }
    private AnimalService _animalService { get; set; }
    private SpecieService _specieService { get; set; }

    public OptionsViewModel(int userId, int postId, PostService postService, LikeService likeService, CommentService commentService, AnimalService animalService, SpecieService specieService, PostDetailView postDetailView)
    {
        UserId = userId;
        PostId = postId;
        PostDetailView = postDetailView;
        _postService = postService;
        _likeService = likeService;
        _commentService = commentService;
        _animalService = animalService;
        _specieService = specieService;

        DeletePostCommand = new RelayCommand(OnDeletePost);
        UpdatePostCommand = new RelayCommand(OnUpdatePost);
        AdoptAnimalCommand = new RelayCommand(OnAdoptAnimal);
        ShowCommentsCommand = new RelayCommand(OnShowComments);
        ShowLikesCommand = new RelayCommand(OnShowLikes);
    }

    private void OnDeletePost()
    {
        _postService.Delete(PostId);
        PostDetailView.Close();
    }

    private void OnUpdatePost()
    {
        new UpdatePostView(PostId, UserId, _postService, _animalService, _specieService).ShowDialog();
        PostDetailView.Close();
    }

    private void OnAdoptAnimal()
    {
        PostDetailView.Close();
    }

    private void OnShowComments()
    {
    }

    private void OnShowLikes()
    {
        new LikesView(UserId, PostId, _postService, _likeService).ShowDialog();
    }
}
