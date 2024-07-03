using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using Backend.Services.VetOfficeServices;
using System.Windows;

namespace Frontend.View
{
    public partial class AdministratorMainPageView : Window
    {
        private SpecieService _specieService;
        private AnimalService _animalService;
        private PostService _postService;
        private LikeService _likeService;
        private CommentService _commentService;
        private TreatmentService _treatmentService;
        private FeedbackService _feedbackService;
        private AdoptionService _adoptionService;
        private DonationService _donationService;

        public AdministratorMainPageView(SpecieService specieService, AnimalService animalService, PostService postService, LikeService likeService, CommentService commentService, TreatmentService treatmentService, FeedbackService feedbackService, AdoptionService adoptionService, DonationService donationService)
        {
            InitializeComponent();

            _specieService = specieService;
            _animalService = animalService;
            _postService = postService;
            _likeService = likeService;
            _commentService = commentService;
            _treatmentService = treatmentService;
            _feedbackService = feedbackService;
            _adoptionService = adoptionService;
            _donationService = donationService;
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

        private void VolunteersButton_Click(object sender, RoutedEventArgs e)
        {
            new VolunteerRegistrationView().Show();
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
            new AdoptionRequestsView().Show();
        }
        
        private void SpeciesButton_Click(object sender, RoutedEventArgs e)
        {
            new AnimalSpeciesView(_specieService, _animalService, _postService, _likeService, _commentService, _treatmentService, _feedbackService, _adoptionService, _donationService).Show();
        }
    }
}
