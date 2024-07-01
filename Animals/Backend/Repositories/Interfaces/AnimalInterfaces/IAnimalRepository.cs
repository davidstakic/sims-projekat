using Backend.Models.AnimalModels;

namespace Backend.Repositories.Interfaces.AnimalInterfaces
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        IEnumerable<Animal> GetAnimalByAnimalSpecieId(int animalSpecieId);
    }
}
