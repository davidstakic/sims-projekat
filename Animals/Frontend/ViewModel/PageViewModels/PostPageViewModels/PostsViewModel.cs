﻿using Backend.Models.AnimalModels;
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
    private User CurrentUser;
    private PostService postService;
    private LikeService likeService;
    private CommentService commentService;
    private AnimalService animalService;
    private SpecieService specieService;
    private AdoptionService adoptionService;
    private DonationService donationService;
    private MemberService memberService;
    private VolunteerService volunteerService;
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

    public PostsViewModel(User currentUser, PostService postService, LikeService likeService, CommentService commentService, AnimalService animalService, SpecieService specieService, AdoptionService adoptionService, DonationService donationService, MemberService memberService, VolunteerService volunteerService)
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
        this.memberService = memberService;
        this.volunteerService = volunteerService;

        this.postService.Subscribe(this);
        this.likeService.Subscribe(this);
        this.commentService.Subscribe(this);
        this.animalService.Subscribe(this);
        this.specieService.Subscribe(this);
        this.adoptionService.Subscribe(this);
        this.donationService.Subscribe(this);
        this.memberService.Subscribe(this);
        this.volunteerService.Subscribe(this);

        Update();
    }

    public void Update()
    {
        var postsData = LoadDataFromFile<Post>("../../../../Backend/Data/Posts.json");
        var likesData = LoadDataFromFile<Like>("../../../../Backend/Data/Likes.json");
        var commentsData = LoadDataFromFile<Comment>("../../../../Backend/Data/Comments.json");
        var animalsData = LoadDataFromFile<Animal>("../../../../Backend/Data/Animals.json");
        var speciesData = LoadDataFromFile<AnimalSpecie>("../../../../Backend/Data/Species.json");

        var postsWithDetails = from post in postsData
                               join like in likesData on post.Id equals like.PostId into postLikes
                               join comment in commentsData on post.Id equals comment.PostId into postComments
                               join animal in animalsData on post.AnimalId equals animal.Id
                               join specie in speciesData on animal.AnimalSpecieId equals specie.Id
                               where post.Status is not Backend.Models.Enums.Status.Waiting
                               select new PostDetailViewModel(CurrentUser, post, animal, specie.Name, postLikes.Count(), postComments.Count(), postService, likeService, commentService, animalService, specieService, adoptionService, donationService, memberService, volunteerService);

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
