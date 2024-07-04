using Frontend.ViewModel.UserViewModels;
using System.Windows;

namespace Frontend.View
{
    public partial class RegistrationRequestsView : Window
    {
        public RegistrationRequestsView()
        {
            InitializeComponent();
            DataContext = new RegistrationRequestsViewModel();
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
