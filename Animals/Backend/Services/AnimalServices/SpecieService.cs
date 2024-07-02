using Backend.Configuration;
using Backend.Models.AnimalModels;
using Backend.Repositories.Interfaces.AnimalInterfaces;

namespace Backend.Services.UserServices
{
    public class SpecieService : Service<AnimalSpecie>
    {
        public SpecieService() : base((ISpecieRepository)Injector.GetRepositoryInstance("ISpecieRepository"))
        {
        }
    }
}
