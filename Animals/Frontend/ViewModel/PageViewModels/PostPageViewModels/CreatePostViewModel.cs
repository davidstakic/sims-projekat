using Backend.Models.AnimalModels;
using Backend.Models.PostModels;
using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.PostServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Frontend.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Frontend.ViewModels
{
    public partial class CreatePostViewModel : ObservableObject
    {
        private SpecieService _animalSpecieService;
        private AnimalService _animalService;
        private PostService _postService;
        private CreatePostView _createPostView;

        [ObservableProperty]
        private string _postTitle;

        [ObservableProperty]
        private string _postDescription;

        [ObservableProperty]
        private string _postImage;

        [ObservableProperty]
        private string _postAnimalName;

        [ObservableProperty]
        private string _postBreed;

        [ObservableProperty]
        private string _postColor;

        [ObservableProperty]
        private DateOnly _postAnimalDate;

        [ObservableProperty]
        private string _postHealth;

        [ObservableProperty]
        private string _postLocation;

        [ObservableProperty]
        private AnimalSpecie _selectedSpecie;

        [ObservableProperty]
        private ObservableCollection<AnimalSpecie> _animalSpecies;

        public User CurrentUser { get; }
        public ICommand CreatePostCommand { get; }

        public CreatePostViewModel(User currentUser, PostService postService, AnimalService animalService, SpecieService specieService, CreatePostView createPostView)
        {
            CurrentUser = currentUser;
            _postService = postService;
            _animalService = animalService;
            _animalSpecieService = specieService;
            _createPostView = createPostView;

            LoadAnimalSpecies();
            CreatePostCommand = new RelayCommand(CreatePost);
        }

        private void LoadAnimalSpecies()
        {
            AnimalSpecies = new ObservableCollection<AnimalSpecie>(_animalSpecieService.GetAll());
        }

        private void CreatePost()
        {
            if (string.IsNullOrWhiteSpace(PostTitle) || string.IsNullOrWhiteSpace(PostDescription) || string.IsNullOrWhiteSpace(PostDescription)
                || string.IsNullOrWhiteSpace(PostImage) || string.IsNullOrWhiteSpace(PostAnimalName) || string.IsNullOrWhiteSpace(PostBreed)
                || string.IsNullOrWhiteSpace(PostColor) || string.IsNullOrWhiteSpace(PostHealth)
                || string.IsNullOrWhiteSpace(PostLocation) || SelectedSpecie == null)
            {
                new PrintMessageView("Not all fields have been filled!").Show();
            } else
            {
                var newAnimal = new Animal
                {
                    Name = PostAnimalName,
                    Breed = PostBreed,
                    Color = PostColor,
                    BirthDate = PostAnimalDate,
                    HealthCondition = PostHealth,
                    Location = PostLocation,
                    AnimalSpecieId = SelectedSpecie.Id
                };

                _animalService.Create(newAnimal);

                var newPost = new Post
                {
                    Title = PostTitle,
                    Description = PostDescription,
                    CreationDate = DateTime.Now,
                    Image = PostImage,
                    Video = "",
                    Status = Backend.Models.Enums.Status.Waiting,
                    AnimalId = newAnimal.Id,
                    UserId = CurrentUser.Id
                };

                _postService.Create(newPost);
                new PrintMessageView("Post successfully created!").Show();
                _createPostView.Close();
            }
        }
    }
}
