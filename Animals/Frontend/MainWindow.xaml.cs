using Backend.Models.Enums;
using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;
using Backend.Services.VetOfficeServices;
using Frontend.View;
using System.Windows;
using System.Windows.Controls;

namespace Frontend
{
    public partial class MainWindow : Window
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

        public MainWindow()
        {
            InitializeComponent();
            _specieService = new SpecieService();
            _animalService = new AnimalService();
            _postService = new PostService();
            _likeService = new LikeService();
            _commentService = new CommentService();
            _treatmentService = new TreatmentService();
            _feedbackService = new FeedbackService();
            _adoptionService = new AdoptionService();
            _donationService = new DonationService();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            ProfileService profileService = new ProfileService();
            Profile loginProfile = profileService.GetByUsernameAndPassword(username, password);
            if (loginProfile == null)
            {
                MessageBox.Show("Username or password incorrect!");
                return;
            }
            MemberService memberService = new MemberService();
            Profile memberProfile;
            foreach (Member member in memberService.GetAll())
            {
                memberProfile = profileService.GetById(member.ProfileId);
                if (loginProfile.Username == memberProfile.Username && loginProfile.Password == memberProfile.Password)
                {
                    if (member.Status == Status.Accepted && !member.IsBlacklisted)
                    {
                        new MemberMainPageView(member).Show();
                        Close();
                        return;
                    }
                    new PostsView(member).Show();
                    Close();
                }
            }
            VolunteerService volunteerService = new VolunteerService();
            Profile volunteerProfile;
            foreach (Volunteer volunteer in volunteerService.GetAll())
            {
                volunteerProfile = profileService.GetById(volunteer.ProfileId);
                if (loginProfile.Username == volunteerProfile.Username && loginProfile.Password == volunteerProfile.Password)
                {
                    if (volunteer.IsAdmin)
                    {
                        new AdministratorMainPageView(_specieService, _animalService, _postService, _likeService, _commentService, _treatmentService, _feedbackService, _adoptionService, _donationService).Show();
                        Close();
                        return;
                    }
                    new VolunteerMainPageView().Show();
                    Close();
                }
            }
            Close();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordText.Visibility = string.IsNullOrEmpty(PasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
        }
        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Forgot Password clicked!");
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationView().Show();
            Close();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}