using Backend.Services.UserServices;
using Frontend.ViewModel.ModelViewModels.UserViewModels;
using Frontend.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class VolunteersView : Window
    {
        private VolunteerService _volunteerService;
        private ProfileService _profileService;

        public VolunteersView(VolunteerService volunteerService, ProfileService profileService)
        {
            InitializeComponent();

            _volunteerService = volunteerService;
            _profileService = profileService;
            DataContext = new VolunteerListViewModel(_volunteerService, _profileService);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new VolunteerRegistrationView(_volunteerService, _profileService).Show();
        }

        private void EditImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is VolunteerViewModel volunteerViewModel)
            {
                var updateWindow = new VolunteerUpdateView(volunteerViewModel);
                updateWindow.Show();
            }
        }

        private void DeleteImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is VolunteerViewModel volunteerViewModel)
            {
                var destructiveActionView = new DestructiveActionView();

                destructiveActionView.OnYesAction = () =>
                {
                    _profileService.Delete(volunteerViewModel.ProfileId);
                    _volunteerService.Delete(volunteerViewModel.Id);
                    new PrintMessageView("Successfuly deleted volunteer.").Show();
                };

                destructiveActionView.ShowDialog();
            }
        }
    }
}
