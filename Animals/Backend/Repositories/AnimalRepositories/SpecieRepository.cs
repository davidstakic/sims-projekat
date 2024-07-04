using Backend.Models.AnimalModels;
using Backend.Repositories.Interfaces.AnimalInterfaces;

namespace Backend.Repositories.AnimalRepositories
{
    public class SpecieRepository : Repository<AnimalSpecie>, ISpecieRepository
    {
        public SpecieRepository(string filePath) : base(filePath)
        {
        }
    }
}
