using System.Windows;

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
    }
}
