using System.Windows;
using System.Windows.Input;
using Backend.Services.UserServices;
using Frontend.ViewModel.ModelViewModels.UserViewModels;

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
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
