using Backend.Models.AssociationModels;

namespace Backend.Repositories.Interfaces.AssociationInterfaces
{
    public interface IDonationRepository : IRepository<Donation>
    {
        IEnumerable<Donation> GetDonationByMemberId(int memberId);
        IEnumerable<Donation> GetDonationByAnimalId(int animalId);
        IEnumerable<Donation> GetDonationByAssociationId(int associationId);
    }
}
