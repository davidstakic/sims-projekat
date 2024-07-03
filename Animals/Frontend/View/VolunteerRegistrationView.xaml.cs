using Backend.Services.UserServices;
using Frontend.ViewModel.ModelViewModels.UserViewModels;
using System.Windows;

namespace Frontend.View
{
    public partial class VolunteerRegistrationView : Window
    {
        public VolunteerViewModel Volunteer { get; set; }

        public VolunteerRegistrationView(VolunteerService volunteerService, ProfileService profileService)
        {
            InitializeComponent();
            Volunteer = new VolunteerViewModel(volunteerService, profileService);
            DataContext = this;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Volunteer.CreateVolunteer();
            Close();
        }
    }
}
