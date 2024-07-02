using Backend.Models.AssociationModels;
using Backend.Models.AnimalModels;
using Backend.Models.UserModels;
using Backend.Services.AssociationServices;
using System.Collections.ObjectModel;
using Backend.Services.AnimalServices;
using Backend.Services.UserServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Frontend.ViewModel.AssociationViewModels
{
    public class DonationsViewModel : ObservableObject
    {
        private readonly DonationService _donationService;
        private readonly MemberService _memberService;
        private readonly AnimalService _animalService;
        private readonly AssociationService _associationService;

        private ObservableCollection<DonationViewModel> _donations;
        public ObservableCollection<DonationViewModel> Donations
        {
            get { return _donations; }
            set { SetProperty(ref _donations, value); }
        }

        public DonationsViewModel()
        {
            _donationService = new DonationService();
            _memberService = new MemberService();  // Replace with your MemberService
            _animalService = new AnimalService();  // Replace with your AnimalService
            _associationService = new AssociationService();  // Replace with your AssociationService

            LoadDonations();
        }

        private void LoadDonations()
        {
            var allDonations = _donationService.GetAll();
            Donations = new ObservableCollection<DonationViewModel>();

            foreach (var donation in allDonations)
            {
                var member = _memberService.GetById(donation.MemberId);
                var animal = _animalService.GetById(donation.AnimalId);
                var association = _associationService.GetById(donation.AssociationId);

                var donationViewModel = new DonationViewModel
                {
                    Donation = donation,
                    Donator = member,
                    Animal = animal,
                    Association = association
                };

                Donations.Add(donationViewModel);
            }
        }
    }

    public class DonationViewModel : ObservableObject
    {
        private Donation _donation;
        public Donation Donation
        {
            get { return _donation; }
            set { SetProperty(ref _donation, value); }
        }

        private Member _donator;
        public Member Donator
        {
            get { return _donator; }
            set { SetProperty(ref _donator, value); }
        }

        private Animal _animal;
        public Animal Animal
        {
            get { return _animal; }
            set { SetProperty(ref _animal, value); }
        }

        private Association _association;
        public Association Association
        {
            get { return _association; }
            set { SetProperty(ref _association, value); }
        }
    }
}
