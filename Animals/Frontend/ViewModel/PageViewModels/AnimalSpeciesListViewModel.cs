using Backend.Services.AnimalServices;
using Observer;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Frontend.ViewModels
{
    public class AnimalSpeciesListViewModel : INotifyPropertyChanged, IObserver
    {
        private SpecieService _specieService;
        private ObservableCollection<AnimalSpecieViewModel> _species;

        public ObservableCollection<AnimalSpecieViewModel> Species
        {
            get { return _species; }
            set
            {
                if (_species != value)
                {
                    _species = value;
                    OnPropertyChanged(nameof(Species));
                }
            }
        }

        public AnimalSpeciesListViewModel(SpecieService specieService)
        {
            _specieService = specieService;
            _specieService.Subscribe(this);
            LoadSpecies();
        }

        private void LoadSpecies()
        {
            var speciesList = _specieService.GetAll();
            Species = new ObservableCollection<AnimalSpecieViewModel>(
                speciesList.Select(s => new AnimalSpecieViewModel(s, _specieService))
            );
        }

        public void Update()
        {
            LoadSpecies();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
