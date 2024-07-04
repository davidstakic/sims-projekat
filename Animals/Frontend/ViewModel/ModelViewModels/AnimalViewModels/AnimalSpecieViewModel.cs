using Backend.Models.AnimalModels;
using Backend.Services.AnimalServices;
using Frontend.View;
using System.ComponentModel;

namespace Frontend.ViewModels
{
    public class AnimalSpecieViewModel : INotifyPropertyChanged
    {
        private SpecieService _specieService;
        private string _name;

        public int Id { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public AnimalSpecieViewModel(SpecieService specieService)
        {
            _specieService = specieService;
        }
        public AnimalSpecieViewModel(AnimalSpecieViewModel animalSpecieViewModel, SpecieService specieService)
        {
            _specieService = specieService;
            Id = animalSpecieViewModel.Id;
            Name = animalSpecieViewModel.Name;
        }
        public AnimalSpecieViewModel(AnimalSpecie animalSpecie, SpecieService specieService)
        {
            _specieService = specieService;
            Id = animalSpecie.Id;
            Name = animalSpecie.Name;
        }

        public void CreateAnimalSpecie()
        {
            if (!IsValid)
            {
                new PrintMessageView("Name must not be empty.").Show();
                return;
            }

            try
            {
                AnimalSpecie newSpecie = new AnimalSpecie(Id, Name);
                _specieService.Create(newSpecie);

                new PrintMessageView("Successfuly created animal specie.").Show();
            }
            catch (Exception ex)
            {
                new PrintMessageView($"Failed to create specie: {ex.Message}").Show();
            }
        }

        public void UpdateAnimalSpecie()
        {
            if (!IsValid)
            {
                new PrintMessageView("Name must not be empty.").Show();
                return;
            }

            try
            {
                AnimalSpecie updatedSpecie = new AnimalSpecie(Id, Name);
                _specieService.Update(updatedSpecie);

                new PrintMessageView("Successfuly updated animal specie.").Show();
            }
            catch (Exception ex)
            {
                new PrintMessageView($"Failed to update specie: {ex.Message}").Show();
            }
        }

        private bool IsValid => !string.IsNullOrEmpty(Name);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
