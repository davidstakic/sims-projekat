using Backend.Models.VetOfficeModels;
using Backend.Repositories.Interface.IRepositoryVetOffice;

namespace Backend.Repositories.VetOfficeRepository
{
    public class TreatmentRepository : Repository<Treatment>, ITreatmentRepository
    {
        public TreatmentRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<Treatment> ITreatmentRepository.GetMessageByAnimalId(int animalId)
        {
            return GetAll().Where(m => m.AnimalId == animalId);
        }

        IEnumerable<Treatment> ITreatmentRepository.GetMessageByVetOfficeId(int vetOfficeId)
        {
            return GetAll().Where(m => m.VetOfficeId == vetOfficeId);
        }
    }
}
