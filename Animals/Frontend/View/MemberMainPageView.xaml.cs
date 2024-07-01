using System.Windows;

namespace Frontend.View
{
    public partial class MemberMainPageView : Window
    {
        public MemberMainPageView()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
