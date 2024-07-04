using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using Backend.Services.VetOfficeServices;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class VolunteerMainPageView : Window
    {
        private Volunteer _Volunteer;
        private SpecieService _specieService;
        private AnimalService _animalService;
        private PostService _postService;
        private LikeService _likeService;
        private CommentService _commentService;
        private AdoptionService _adoptionService;
        private DonationService _donationService;

        public VolunteerMainPageView(Volunteer volunteer, SpecieService specieService, AnimalService animalService, PostService postService, LikeService likeService, CommentService commentService, TreatmentService treatmentService, FeedbackService feedbackService, AdoptionService adoptionService, DonationService donationService)
        {
            InitializeComponent();

            _Volunteer = volunteer;

            _specieService = specieService;
            _animalService = animalService;
            _postService = postService;
            _likeService = likeService;
            _commentService = commentService;
            _adoptionService = adoptionService;
            _donationService = donationService;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void Donations_Click(object sender, RoutedEventArgs e)
        {
            new DonationsView().Show();
        }

        private void RegistrationRequests_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationRequestsView().Show();
        }

        private void PostRequests_Click(object sender, RoutedEventArgs e)
        {
            new PostRequestsView().Show();
        }

        private void AdoptionRequests_Click(object sender, RoutedEventArgs e)
        {
            new AdoptionRequestsView(_postService, _commentService, _likeService).Show();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Members_Click(object sender, RoutedEventArgs e)
        {
            new MembersView().Show();
        }

        private void Posts_Click(object sender, RoutedEventArgs e)
        {
            new PostsView(_Volunteer, _postService, _likeService, _commentService, _animalService, _specieService, _adoptionService, _donationService).Show();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
