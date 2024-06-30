using Backend.Models.AssociationModels;
using Backend.Repositories.Interface.IAssociationRepository;

namespace Backend.Repositories.AssociationRepository
{
    public class DonationRepository : Repository<Donation>, IDonationRepository
    {
        public DonationRepository(string filePath) : base(filePath)
        {
        }

        public IEnumerable<Donation> GetDonationByAnimalId(int animalId)
        {
            return GetAll().Where(m => m.AnimalId == animalId);
        }

        public IEnumerable<Donation> GetDonationByAssociationId(int associationId)
        {
            return GetAll().Where(m => m.AssociationId == associationId);
        }

        public IEnumerable<Donation> GetDonationByMemberId(int memberId)
        {
            return GetAll().Where(m => m.MemberId == memberId);
        }
    }
}
