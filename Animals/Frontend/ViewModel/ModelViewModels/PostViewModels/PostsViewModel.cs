using Backend.Models.AnimalModels;
using Backend.Models.PostModels;
using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;
using CommunityToolkit.Mvvm.Input;
using Frontend.View;
using Newtonsoft.Json;
using Observer;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;

public class PostsViewModel : INotifyPropertyChanged, IObserver
{
    private User CurrentUser { get; set; }
    private PostService postService { get; set; }
    private LikeService likeService { get; set; }
    private CommentService commentService { get; set; }
    private AnimalService animalService { get; set; }
    private SpecieService specieService { get; set; }
    private AdoptionService adoptionService { get; set; }
    private DonationService donationService { get; set; }
    private ObservableCollection<PostDetailViewModel> posts;
    public ObservableCollection<PostDetailViewModel> Posts
    {
        get { return posts; }
        set
        {
            posts = value;
            OnPropertyChanged("Posts");
        }
    }
    public ICommand CreateCommand { get; }

    public PostsViewModel(User currentUser, PostService postService, LikeService likeService, CommentService commentService, AnimalService animalService, SpecieService specieService, AdoptionService adoptionService, DonationService donationService)
    {
        CreateCommand = new RelayCommand(OnCreate);
        CurrentUser = currentUser;
        this.postService = postService;
        this.likeService = likeService;
        this.commentService = commentService;
        this.animalService = animalService;
        this.specieService = specieService;
        this.adoptionService = adoptionService;
        this.donationService = donationService;

        this.postService.Subscribe(this);
        this.likeService.Subscribe(this);
        this.commentService.Subscribe(this);
        this.animalService.Subscribe(this);
        this.specieService.Subscribe(this);
        this.adoptionService.Subscribe(this);
        this.donationService.Subscribe(this);

        Update();
    }

    public void Update()
    {
        var postsData = LoadDataFromFile<Post>("../../../../Backend/Data/Posts.json");
        var likesData = LoadDataFromFile<Like>("../../../../Backend/Data/Likes.json");
        var commentsData = LoadDataFromFile<Comment>("../../../../Backend/Data/Comments.json");
        var memberData = LoadDataFromFile<Member>("../../../../Backend/Data/Members.json");
        var animalsData = LoadDataFromFile<Animal>("../../../../Backend/Data/Animals.json");
        var speciesData = LoadDataFromFile<AnimalSpecie>("../../../../Backend/Data/Species.json");

        var postsWithDetails = from post in postsData
                               join like in likesData on post.Id equals like.PostId into postLikes
                               join comment in commentsData on post.Id equals comment.PostId into postComments
                               join member in memberData on post.UserId equals member.Id
                               join animal in animalsData on post.AnimalId equals animal.Id
                               join specie in speciesData on animal.AnimalSpecieId equals specie.Id
                               where post.Status is not Backend.Models.Enums.Status.Waiting
                               select new PostDetailViewModel(CurrentUser, post, member, animal, specie.Name, postLikes.Count(), postComments.Count(), postService, likeService, commentService, animalService, specieService, adoptionService, donationService);

        postsWithDetails = postsWithDetails.OrderBy(post => post.Post.Id);

        Posts = new ObservableCollection<PostDetailViewModel>(postsWithDetails);
    }


    private ObservableCollection<T> LoadDataFromFile<T>(string fileName)
    {
        var jsonData = File.ReadAllText(fileName);
        return JsonConvert.DeserializeObject<ObservableCollection<T>>(jsonData)!;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private void OnCreate()
    {
        new CreatePostView(CurrentUser, postService, animalService, specieService).ShowDialog();
        Update();
    }
}
