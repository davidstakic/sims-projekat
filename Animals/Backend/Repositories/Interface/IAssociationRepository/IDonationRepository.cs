using Backend.Models.AssociationModels;

namespace Backend.Repositories.Interface.IAssociationRepository
{
    public interface IDonationRepository
    {
        IEnumerable<Donation> GetDonationByMemberId(int memberId);
        IEnumerable<Donation> GetDonationByAnimalId(int animalId);
        IEnumerable<Donation> GetDonationByAssociationId(int associationId);
    }
}
