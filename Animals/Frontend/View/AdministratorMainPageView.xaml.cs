using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;
using Backend.Services.VetOfficeServices;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class AdministratorMainPageView : Window
    {
        private Volunteer _Volunteer;
        private SpecieService _specieService;
        private AnimalService _animalService;
        private PostService _postService;
        private LikeService _likeService;
        private CommentService _commentService;
        private TreatmentService _treatmentService;
        private FeedbackService _feedbackService;
        private AdoptionService _adoptionService;
        private DonationService _donationService;
        private VolunteerService _volunterService;
        private ProfileService _profileService;

        public AdministratorMainPageView(Volunteer volunteer, SpecieService specieService, AnimalService animalService, PostService postService, LikeService likeService, CommentService commentService, TreatmentService treatmentService, FeedbackService feedbackService, AdoptionService adoptionService, DonationService donationService, VolunteerService volunteerService, ProfileService profileService)
        {
            InitializeComponent();

            _Volunteer = volunteer;

            _specieService = specieService;
            _animalService = animalService;
            _postService = postService;
            _likeService = likeService;
            _commentService = commentService;
            _treatmentService = treatmentService;
            _feedbackService = feedbackService;
            _adoptionService = adoptionService;
            _donationService = donationService;
            _volunterService = volunteerService;
            _profileService = profileService;
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
            new VolunteersView(_volunterService, _profileService).Show();
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
