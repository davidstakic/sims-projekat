using Backend.Models.VetOfficeModels;
using Backend.Repositories.Interfaces.VetOfficeInterfaces;

namespace Backend.Repositories.VetOfficeRepositories
{
    public class TreatmentRepository : Repository<Treatment>, ITreatmentRepository
    {
        public TreatmentRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<Treatment> ITreatmentRepository.GetTreatmentByAnimalId(int animalId)
        {
            return GetAll().Where(m => m.AnimalId == animalId);
        }
    }
}
