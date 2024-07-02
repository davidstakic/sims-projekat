using Backend.Models.AnimalModels;
using Backend.Models.PostModels;
using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Frontend.ViewModels
{
    public partial class CreatePostViewModel : ObservableObject
    {
        private SpecieService _animalSpecieService = new SpecieService();
        private AnimalService _animalService = new AnimalService();
        private PostService _postService = new PostService();

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

        public Member CurrentMember { get; }
        public ICommand CreatePostCommand { get; }

        public CreatePostViewModel(Member currentMember)
        {
            CurrentMember = currentMember;
            LoadAnimalSpecies();
            CreatePostCommand = new RelayCommand(CreatePost);
        }

        private void LoadAnimalSpecies()
        {
            AnimalSpecies = new ObservableCollection<AnimalSpecie>(_animalSpecieService.GetAll());
        }

        private void CreatePost()
        {
            var newPost = new Post
            {
                Title = PostTitle,
                Description = PostDescription,
                CreationDate = DateTime.Now,
                Image = PostImage,
                Video = "",
                Status = Backend.Models.Enums.Status.Waiting,
                AnimalId = SelectedSpecie.Id,
                UserId = CurrentMember.Id
            };

            _postService.Create(newPost);

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
        }
    }
}
