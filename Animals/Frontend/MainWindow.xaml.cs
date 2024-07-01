using Backend.Models.Enums;
using Backend.Models.UserModels;
using Backend.Services.UserServices;
using Frontend.View;
using System.Windows;
using System.Windows.Controls;

namespace Frontend
{
    public partial class MainWindow : Window
    {
        //private ProfilesController _profilesController { get; set; }
        //private StudentsController _studentsController { get; set; }
        //private ProfessorsController _professorsController { get; set; }
        //private ProfessorGradesController _professorGradesController { get; set; }
        public MainWindow()
        {
            InitializeComponent();          
            //new Database().CreateAndPopulateTables();
            //_profilesController = new ProfilesController();
            //_studentsController = new StudentsController();
            //_studentsController.ReducePenaltyPoints(_profilesController);
            //_professorsController = new ProfessorsController();
            //_professorGradesController = new ProfessorGradesController();
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
                    if (member.Status == Status.Accepted || !member.IsBlacklisted)
                    {
                        new MemberMainPageView().Show();
                        Close();
                        return;
                    }
                    new PostsView().Show();
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
            new MemberMainPageView().Show();
            //new RegistrationMenu(_studentsController).Show();
            Close();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Posts_Click(object sender, RoutedEventArgs e)
        {
            new PostsView().Show();
            Close();
        }
    }
}