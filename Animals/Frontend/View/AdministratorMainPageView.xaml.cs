using System.Windows;

namespace Frontend.View
{
    public partial class AdministratorMainPageView : Window
    {
        public AdministratorMainPageView()
        {
            InitializeComponent();
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
    }
}
