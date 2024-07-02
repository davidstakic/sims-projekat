using Backend.Models.UserModels;
using System.Windows;

namespace Frontend.View
{
    public partial class MemberMainPageView : Window
    {
        private Member currentMember { get; set; }
        public MemberMainPageView(Member currentMember)
        {
            InitializeComponent();
            this.currentMember = currentMember;
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

        private void Posts_Click(object sender, RoutedEventArgs e)
        {
            new PostsView(currentMember).Show();
        }

        private void Donate_Click(object sender, RoutedEventArgs e)
        {
            new DonationView(currentMember).Show();
        }
    }
}
