using Backend.Models.AssociationModels;
using Backend.Repositories.Interfaces.AssociationInterfaces;

namespace Backend.Repositories.AssociationRepositories
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
    }
}
