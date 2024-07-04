using Frontend.ViewModel.ModelViewModels.UserViewModels;
using System.Windows;

namespace Frontend.View
{
    public partial class VolunteerUpdateView : Window
    {
        public VolunteerViewModel Volunteer { get; set; }

        public VolunteerUpdateView(VolunteerViewModel volunteer)
        {
            InitializeComponent();
            Volunteer = volunteer;
            DataContext = this;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Volunteer.UpdateVolunteer();
            Close();
        }
    }
}
