using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class MemberMainPageView : Window
    {
        private Member currentMember { get; set; }
        private PostService postService { get; set; }
        private LikeService likeService { get; set; }
        private CommentService commentService { get; set; }
        private AnimalService animalService { get; set; }
        private SpecieService specieService { get; set; }
        private AdoptionService adoptionService { get; set; }
        private DonationService donationService { get; set; }
        public MemberMainPageView(Member currentMember, PostService postService, LikeService likeService, CommentService commentService, AnimalService animalService, SpecieService specieService, AdoptionService adoptionService, DonationService donationService)
        {
            InitializeComponent();
            this.currentMember = currentMember;
            this.postService = postService;
            this.likeService = likeService;
            this.commentService = commentService;
            this.animalService = animalService;
            this.specieService = specieService;
            this.adoptionService = adoptionService;
            this.donationService = donationService;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void Posts_Click(object sender, RoutedEventArgs e)
        {
            new PostsView(currentMember, postService, likeService, commentService, animalService, specieService, adoptionService, donationService).Show();
        }

        private void Donate_Click(object sender, RoutedEventArgs e)
        {
            new DonationView(currentMember).Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            new MemberUpdateView(currentMember).Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            new ProfileService().Delete(currentMember.ProfileId);
            new MemberService().Delete(currentMember.Id);
            new MainWindow().Show();
            Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
