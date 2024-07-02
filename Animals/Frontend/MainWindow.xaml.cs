using Backend.Models.Enums;
using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;
using Frontend.View;
using System.Windows;
using System.Windows.Controls;

namespace Frontend
{
    public partial class MainWindow : Window
    {
        public PostService postService = new();
        public LikeService likeService = new();
        public CommentService commentService = new();
        public AnimalService animalService = new();
        public SpecieService specieService = new();
        public MainWindow()
        {
            InitializeComponent();
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
                        new MemberMainPageView(member, postService, likeService, commentService, animalService, specieService).Show();
                        Close();
                        return;
                    }
                    new PostsView(member, postService, likeService, commentService, animalService, specieService).Show();
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
                        new AdministratorMainPageView().Show();
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