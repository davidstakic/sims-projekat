using Backend.Configuration;
using Backend.Models.AnimalModels;
using Backend.Repositories.Interfaces.AnimalInterfaces;

namespace Backend.Services.AnimalServices
{
    public class AdoptionService : Service<Adoption>
    {
        public AdoptionService() : base((IAdoptionRepository)Injector.GetRepositoryInstance("IAdoptionRepository"))
        {
        }

        public List<Adoption> GetAdoptionByAnimalId(int animalId)
        {
            return GetAll().Where(m => m.AnimalId == animalId).ToList();
        }

        public List<Adoption> GetAdoptionByMemberId(int memberId)
        {
            return GetAll().Where(m => m.MemberId == memberId).ToList();
        }
    }
}
