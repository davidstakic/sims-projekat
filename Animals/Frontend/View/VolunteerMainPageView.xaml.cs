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

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
