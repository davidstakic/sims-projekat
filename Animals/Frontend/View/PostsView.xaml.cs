using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using Frontend.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend
{
    public partial class PostsView : Window
    {
        private User currentUser { get; set; }
        private LikeService likeService { get; set; }
        private CommentService commentService { get; set; }
        private AnimalService animalService { get; set; }
        private SpecieService specieService { get; set; }
        private AdoptionService adoptionService { get; set; }
        private DonationService donationService { get; set; }
        public PostsView(User currentUser, PostService postService, LikeService likeService, CommentService commentService, AnimalService animalService, SpecieService specieService, AdoptionService adoptionService, DonationService donationService)
        {
            InitializeComponent();
            DataContext = new PostsViewModel(currentUser, postService, likeService, commentService, animalService, specieService, adoptionService, donationService);
            this.currentUser = currentUser;
            this.likeService = likeService;
            this.commentService = commentService;
            this.animalService = animalService;
            this.specieService = specieService;
            this.adoptionService = adoptionService;
            this.donationService = donationService;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PostBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border && border.DataContext is PostDetailViewModel postViewModel)
            {
                new PostDetailView(postViewModel).ShowDialog();
            }
        }
    }
}
