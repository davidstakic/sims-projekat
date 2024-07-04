using Backend.Models.AnimalModels;
using Backend.Models.Enums;
using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Frontend.View;
using System.Windows.Input;

public class OptionsViewModel : ObservableObject
{
    private PostService _postService;
    private LikeService _likeService;
    private CommentService _commentService;
    private AnimalService _animalService;
    private SpecieService _specieService;
    private AdoptionService _adoptionService;
    private DonationService _donationService;

    public int UserId { get; }
    public int PostId { get; }
    public ICommand DeletePostCommand { get; }
    public ICommand UpdatePostCommand { get; }
    public ICommand AdoptAnimalCommand { get; }
    public ICommand ShowCommentsCommand { get; }
    public ICommand ShowLikesCommand { get; }
    public PostDetailView PostDetailView { get; }

    public OptionsViewModel(int userId, int postId, PostService postService, LikeService likeService, CommentService commentService, AnimalService animalService, SpecieService specieService, AdoptionService adoptionService, DonationService donationService, PostDetailView postDetailView)
    {
        UserId = userId;
        PostId = postId;
        PostDetailView = postDetailView;
        _postService = postService;
        _likeService = likeService;
        _commentService = commentService;
        _animalService = animalService;
        _specieService = specieService;
        _adoptionService = adoptionService;
        _donationService = donationService;

        DeletePostCommand = new RelayCommand(OnDeletePost);
        UpdatePostCommand = new RelayCommand(OnUpdatePost);
        AdoptAnimalCommand = new RelayCommand(OnAdoptAnimal);
        ShowCommentsCommand = new RelayCommand(OnShowComments);
        ShowLikesCommand = new RelayCommand(OnShowLikes);
    }

    private void OnDeletePost()
    {
        var actionView = new ActionView("Are you sure you want to delete this post?");
        actionView.OnYesAction = () =>
        {
            DeletePost(PostId);
            PostDetailView.Close();
        };

        actionView.ShowDialog();
    }

    private void OnUpdatePost()
    {
        new UpdatePostView(PostId, UserId, _postService, _animalService, _specieService).ShowDialog();
        PostDetailView.Close();
    }

    private void OnAdoptAnimal()
    {
        var actionView = new ActionView("Are you sure you wish to adopt this animal?");
        actionView.OnYesAction = () =>
        {
            _adoptionService.Create(new Adoption(1, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddMonths(1)), Status.Waiting, UserId, _postService.GetById(PostId).AnimalId));
            PostDetailView.Close();
        };

        actionView.ShowDialog();
    }

    private void OnShowComments()
    {
        new CommentsView(UserId, PostId, _commentService).ShowDialog();
    }

    private void OnShowLikes()
    {
        new LikesView(UserId, PostId, _likeService).ShowDialog();
    }

    private void DeletePost(int postId)
    {
        DeleteComments(postId);
        DeleteLikes(postId);
        DeleteAnimal(postId);
        _postService.Delete(postId);
    }

    private void DeleteAnimal(int postId)
    {
        Animal animal = _animalService.GetById(_postService.GetById(postId).AnimalId);
        DeleteRelatedAdoptions(animal.Id);
        DeleteRelatedDonations(animal.Id);
        _animalService.Delete(animal.Id);
    }
    
    private void DeleteRelatedAdoptions(int animalId)
    {
        var adoptionsToDelete = _adoptionService.GetAdoptionByAnimalId(animalId);

        foreach (var adoption in adoptionsToDelete)
        {
            _adoptionService.Delete(adoption.Id);
        }
    }

    private void DeleteRelatedDonations(int animalId)
    {
        var donationsToDelete = _donationService.GetDonationByAnimalId(animalId);

        foreach (var donation in donationsToDelete)
        {
            donation.AnimalId = -1;
            _donationService.Update(donation);
        }
    }

    private void DeleteLikes(int postId)
    {
        var likesToDelete = _likeService.GetLikeByPostId(postId);

        foreach (var like in likesToDelete)
        {
            _likeService.Delete(like.Id);
        }
    }

    private void DeleteComments(int postId)
    {
        var commentsToDelete = _commentService.GetCommentByPostId(postId).ToList();

        foreach (var comment in commentsToDelete)
        {
            _commentService.Delete(comment.Id);
        }
    }
}
