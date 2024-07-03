using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class VolunteerRegistrationView : Window
    {
        public VolunteerRegistrationView()
        {
            InitializeComponent();
        }
        
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordText.Visibility = string.IsNullOrEmpty(PasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
