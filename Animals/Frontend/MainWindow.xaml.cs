using Frontend.View;
using Frontend.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Frontend
{
    public partial class MainWindow : Window
    {
        private readonly LoginViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel();
            DataContext = _viewModel;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Username = UsernameTextBox.Text;
            _viewModel.Password = PasswordBox.Password;
            _viewModel.Login();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordText.Visibility = string.IsNullOrEmpty(PasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            new PrintMessageView("Forgot Password clicked!").Show();
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