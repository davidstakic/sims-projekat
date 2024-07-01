using Backend.Configuration;
using Backend.Models.AnimalModels;
using Backend.Repositories.Interfaces.AnimalInterfaces;

namespace Backend.Services.AnimalServices
{
    public class AnimalService : Service<Animal>
    {
        public AnimalService() : base((IAnimalRepository)Injector.GetRepositoryInstance("IAnimalRepository"))
        {
        }
    }
}
