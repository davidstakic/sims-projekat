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
    }
}
