﻿using Backend.Models.AnimalModels;
using Backend.Models.Enums;
using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using CommunityToolkit.Mvvm.Input;
using Frontend.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Frontend.ViewModel.ModelViewModels.AnimalViewModels
{
    public class AdoptionRequestsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Adoption>? _pendingAdoptions;

        public ObservableCollection<Adoption>? PendingAdoptions
        {
            get { return _pendingAdoptions; }
            set
            {
                _pendingAdoptions = value;
                OnPropertyChanged(nameof(PendingAdoptions));
            }
        }

        public ICommand AcceptAdoptionCommand { get; private set; }
        public ICommand RejectAdoptionCommand { get; private set; }

        public AdoptionRequestsViewModel()
        {
            AcceptAdoptionCommand = new RelayCommand<Adoption>(AcceptAdoption);
            RejectAdoptionCommand = new RelayCommand<Adoption>(RejectAdoption);

            LoadPendingAdoptions();
        }

        private void LoadPendingAdoptions()
        {
            var adoptionService = new AdoptionService();
            var allAdoptions = adoptionService.GetAll();
            var pendingAdoptions = new List<Adoption>();

            foreach (var adoption in allAdoptions)
            {
                if (adoption.Status == Status.Waiting)
                {
                    pendingAdoptions.Add(adoption);
                }
            }

            PendingAdoptions = new ObservableCollection<Adoption>(pendingAdoptions);
        }

        private void AcceptAdoption(Adoption? adoption)
        {
            if (adoption != null)
            {
                adoption.Status = Status.Accepted;
                new AdoptionService().Update(adoption);
                new PrintMessageView("Adoption has been accepted").Show();
                LoadPendingAdoptions();
            }
        }

        private void RejectAdoption(Adoption? adoption)
        {
            if (adoption != null)
            {
                new AdoptionService().Delete(adoption.Id);
                new PrintMessageView("Adoption has been rejected").Show();
                LoadPendingAdoptions();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
