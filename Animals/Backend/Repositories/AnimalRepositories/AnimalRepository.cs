using Backend.Models.AnimalModels;
using Backend.Repositories.Interfaces.AnimalInterfaces;

namespace Backend.Repositories.AnimalRepositories
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<Animal> IAnimalRepository.GetAnimalByAnimalSpecieId(int animalSpecieId)
        {
            return GetAll().Where(m => m.AnimalSpecieId == animalSpecieId);
        }
    }
}
