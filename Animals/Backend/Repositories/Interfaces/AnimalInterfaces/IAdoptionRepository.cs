using Backend.Models.AnimalModels;

namespace Backend.Repositories.Interfaces.AnimalInterfaces
{
    public interface IAdoptionRepository : IRepository<Adoption>
    {
        IEnumerable<Adoption> GetAdoptionByMemberId(int memberId);
        IEnumerable<Adoption> GetAdoptionByAnimalId(int animalId);
    }
}
