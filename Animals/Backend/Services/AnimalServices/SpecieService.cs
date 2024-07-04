using Backend.Configuration;
using Backend.Models.AnimalModels;
using Backend.Repositories.Interfaces.AnimalInterfaces;

namespace Backend.Services.AnimalServices
{
    public class SpecieService : Service<AnimalSpecie>
    {
        private readonly ISpecieRepository _specieRepository;
        public SpecieService() : base((ISpecieRepository)Injector.GetRepositoryInstance("ISpecieRepository"))
        {
            _specieRepository = (ISpecieRepository)Injector.GetRepositoryInstance("ISpecieRepository");
        }
    }
}
