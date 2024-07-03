using Backend.Services.UserServices;
using Frontend.ViewModel.ModelViewModels.UserViewModels;
using Observer;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Frontend.ViewModels
{
    public class VolunteerListViewModel : INotifyPropertyChanged, IObserver
    {
        private VolunteerService _volunteerService;
        private ProfileService _profileService;
        private ObservableCollection<VolunteerViewModel> _volunteers;

        public ObservableCollection<VolunteerViewModel> Volunteers
        {
            get { return _volunteers; }
            set
            {
                if (_volunteers != value)
                {
                    _volunteers = value;
                    OnPropertyChanged(nameof(Volunteers));
                }
            }
        }

        public VolunteerListViewModel(VolunteerService volunteerService, ProfileService profileService)
        {
            _volunteerService = volunteerService;
            _volunteerService.Subscribe(this);
            _profileService = profileService;
            _profileService.Subscribe(this);
            LoadVolunteers();
        }

        private void LoadVolunteers()
        {
            var volunteerList = _volunteerService.GetAll();
            Volunteers = new ObservableCollection<VolunteerViewModel>(
                volunteerList.Select(v => new VolunteerViewModel(v, _volunteerService, _profileService))
            );
        }

        public void Update()
        {
            LoadVolunteers();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
