using Backend.Models.AnimalModels;
using Backend.Repositories.Interface.IAnimalRepository;

namespace Backend.Repositories.AnimalRepository
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
