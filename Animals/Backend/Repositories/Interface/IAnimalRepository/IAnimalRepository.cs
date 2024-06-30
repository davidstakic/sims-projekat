using Backend.Models.AnimalModels;

namespace Backend.Repositories.Interface.IAnimalRepository
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAnimalByAnimalSpecieId(int animalSpecieId);
    }
}
