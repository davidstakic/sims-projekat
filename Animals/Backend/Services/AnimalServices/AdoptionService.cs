using Backend.Configuration;
using Backend.Models.AnimalModels;
using Backend.Repositories.Interfaces.AnimalInterfaces;

namespace Backend.Services.AnimalServices
{
    public class AdoptionService : Service<Adoption>
    {
        protected readonly IAdoptionRepository _adoptionRepository;
        public AdoptionService() : base((IAdoptionRepository)Injector.GetRepositoryInstance("IAdoptionRepository"))
        {
            _adoptionRepository = (IAdoptionRepository)Injector.GetRepositoryInstance("IAdoptionRepository");
        }

        public List<Adoption> GetAdoptionByAnimalId(int animalId)
        {
            return _adoptionRepository.GetAdoptionByAnimalId(animalId).ToList();
        }

        public List<Adoption> GetAdoptionByUserId(int userId)
        {
            return _adoptionRepository.GetAdoptionByUserId(userId).ToList();
        }
    }
}
