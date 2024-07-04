using Backend.Configuration;
using Backend.Models.AssociationModels;
using Backend.Repositories.Interfaces.AssociationInterfaces;

namespace Backend.Services.AssociationServices
{
    public class DonationService : Service<Donation>
    {
        private readonly IDonationRepository _donationRepository;
        public DonationService() : base((IDonationRepository)Injector.GetRepositoryInstance("IDonationRepository"))
        {
            _donationRepository = (IDonationRepository)Injector.GetRepositoryInstance("IDonationRepository");
        }

        public List<Donation> GetDonationByAnimalId(int animalId)
        {
            return _donationRepository.GetDonationByAnimalId(animalId).ToList();
        }
    }
}
