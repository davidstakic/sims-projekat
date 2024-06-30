using Backend.Models.AnimalModels;
using Backend.Repositories.Interface.IAnimalRepository;

namespace Backend.Repositories.AnimalRepository
{
    public class AdoptionRepository : Repository<Adoption>, IAdoptionRepository
    {
        public AdoptionRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<Adoption> IAdoptionRepository.GetAdoptionByAnimalId(int animalId)
        {
            return GetAll().Where(m => m.AnimalId == animalId);
        }

        IEnumerable<Adoption> IAdoptionRepository.GetAdoptionByMemberId(int memberId)
        {
            return GetAll().Where(m => m.MemberId == memberId);
        }
    }
}
