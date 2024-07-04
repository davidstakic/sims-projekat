using Backend.Models.AnimalModels;

namespace Backend.Repositories.Interfaces.AnimalInterfaces
{
    public interface IAdoptionRepository : IRepository<Adoption>
    {
        IEnumerable<Adoption> GetAdoptionByAnimalId(int animalId);
        IEnumerable<Adoption> GetAdoptionByUserId(int userId);
    }
}
