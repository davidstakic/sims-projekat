using Backend.Models.AssociationModels;

namespace Backend.Repositories.Interfaces.AssociationInterfaces
{
    public interface IDonationRepository : IRepository<Donation>
    {
        IEnumerable<Donation> GetDonationByAnimalId(int animalId);
    }
}
