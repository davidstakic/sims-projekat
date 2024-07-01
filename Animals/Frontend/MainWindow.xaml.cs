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
            //new LoginMenu(_studentsController, _professorsController, _professorGradesController).Show();
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            MessageBox.Show($"Attempting to log in with Email: {email} and Password: {password}");
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
            new VolunteerRegistrationView().Show();
            //new RegistrationMenu(_studentsController).Show();
            Close();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}