using Backend.Models.AnimalModels;
using Backend.Models.PostModels;
using Backend.Services.AnimalServices;
using Backend.Services.PostServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Frontend.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Frontend.ViewModels
{
    public partial class UpdatePostViewModel : ObservableObject
    {
        private readonly SpecieService _animalSpecieService;
        private readonly AnimalService _animalService;
        private readonly PostService _postService;
        private int _userId;

        [ObservableProperty]
        private int _postId;

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
        private DateTime _postAnimalDate;

        [ObservableProperty]
        private string _postHealth;

        [ObservableProperty]
        private string _postLocation;

        [ObservableProperty]
        private AnimalSpecie _selectedSpecie;

        [ObservableProperty]
        private ObservableCollection<AnimalSpecie> _animalSpecies;

        public ICommand UpdatePostCommand { get; }

        public UpdatePostViewModel(int postId, int userId, PostService postService, AnimalService animalService, SpecieService animalSpecieService)
        {
            _postId = postId;
            _userId = userId;
            _animalSpecieService = animalSpecieService;
            _animalService = animalService;
            _postService = postService;

            LoadAnimalSpecies();
            LoadPostDetails();
            UpdatePostCommand = new RelayCommand(UpdatePost);
        }

        private void LoadAnimalSpecies()
        {
            AnimalSpecies = new ObservableCollection<AnimalSpecie>(_animalSpecieService.GetAll());
        }

        private void LoadPostDetails()
        {
            var post = _postService.GetById(_postId);
            if (post != null)
            {
                PostTitle = post.Title;
                PostDescription = post.Description;
                PostImage = post.Image;

                var animal = _animalService.GetById(post.AnimalId);
                if (animal != null)
                {
                    PostAnimalName = animal.Name;
                    PostBreed = animal.Breed;
                    PostColor = animal.Color;
                    PostAnimalDate = animal.BirthDate.ToDateTime(TimeOnly.MinValue);
                    PostHealth = animal.HealthCondition;
                    PostLocation = animal.Location;
                    SelectedSpecie = _animalSpecieService.GetById(animal.AnimalSpecieId);
                }
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(PostTitle) ||
                string.IsNullOrWhiteSpace(PostDescription) ||
                string.IsNullOrWhiteSpace(PostImage) ||
                string.IsNullOrWhiteSpace(PostAnimalName) ||
                string.IsNullOrWhiteSpace(PostBreed) ||
                string.IsNullOrWhiteSpace(PostColor) ||
                string.IsNullOrWhiteSpace(PostHealth) ||
                string.IsNullOrWhiteSpace(PostLocation) ||
                SelectedSpecie == null)
            {
                new PrintMessageView("Not all data was inputed!").ShowDialog();
                return false;
            }

            return true;
        }

        private void UpdatePost()
        {
            if (!ValidateFields())
                return;

            var updatedPost = new Post
            {
                Id = PostId,
                Title = PostTitle,
                Description = PostDescription,
                CreationDate = DateTime.Now,
                Image = PostImage,
                Video = "",
                Status = Backend.Models.Enums.Status.Waiting,
                AnimalId = SelectedSpecie.Id,
                UserId = _userId
            };

            var updatedAnimal = new Animal
            {
                Id = updatedPost.AnimalId,
                Name = PostAnimalName,
                Breed = PostBreed,
                Color = PostColor,
                BirthDate = DateOnly.FromDateTime(PostAnimalDate),
                HealthCondition = PostHealth,
                Location = PostLocation,
                AnimalSpecieId = SelectedSpecie.Id
            };

            var actionView = new ActionView("Are you sure you want to update this post?");
            actionView.OnYesAction = () =>
            {
                _postService.Update(updatedPost);
                _animalService.Update(updatedAnimal);
            };

            actionView.ShowDialog();
        }
    }
}
