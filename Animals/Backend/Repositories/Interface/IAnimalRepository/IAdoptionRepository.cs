using Backend.Models.AnimalModels;

namespace Backend.Repositories.Interface.IAnimalRepository
{
    public interface IAdoptionRepository
    {
        IEnumerable<Adoption> GetAdoptionByMemberId(int memberId);
        IEnumerable<Adoption> GetAdoptionByAnimalId(int animalId);
    }
}
