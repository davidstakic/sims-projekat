using System.Windows;

namespace Frontend.View
{
    public partial class VolunteerMainPageView : Window
    {
        public VolunteerMainPageView()
        {
            InitializeComponent();
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

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
