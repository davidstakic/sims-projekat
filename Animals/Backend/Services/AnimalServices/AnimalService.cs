using Backend.Configuration;
using Backend.Models.AnimalModels;
using Backend.Repositories.Interfaces.AnimalInterfaces;

namespace Backend.Services.AnimalServices
{
    public class AnimalService : Service<Animal>
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalService() : base((IAnimalRepository)Injector.GetRepositoryInstance("IAnimalRepository"))
        {
            _animalRepository = (IAnimalRepository)Injector.GetRepositoryInstance("IAnimalRepository");
        }

        public List<Animal> GetAnimalByAnimalSpecieId(int animalSpecieId)
        {
            return _animalRepository.GetAnimalByAnimalSpecieId(animalSpecieId).ToList();
        }
    }
}
