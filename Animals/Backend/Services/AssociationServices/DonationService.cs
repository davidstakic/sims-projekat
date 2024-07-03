using Backend.Configuration;
using Backend.Models.AssociationModels;
using Backend.Repositories.Interfaces.AssociationInterfaces;

namespace Backend.Services.AssociationServices
{
    public class DonationService : Service<Donation>
    {
        public DonationService() : base((IDonationRepository)Injector.GetRepositoryInstance("IDonationRepository"))
        {
        }

        public List<Donation> GetDonationByAnimalId(int animalId)
        {
            return GetAll().Where(m => m.AnimalId == animalId).ToList();
        }

        public List<Donation> GetDonationByAssociationId(int associationId)
        {
            return GetAll().Where(m => m.AssociationId == associationId).ToList();
        }

        public List<Donation> GetDonationByMemberId(int memberId)
        {
            return GetAll().Where(m => m.MemberId == memberId).ToList();
        }
    }
}
