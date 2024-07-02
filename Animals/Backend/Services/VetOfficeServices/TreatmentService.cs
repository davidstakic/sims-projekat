using Backend.Configuration;
using Backend.Models.VetOfficeModels;
using Backend.Repositories.Interfaces.VetOfficeInterfaces;

namespace Backend.Services.VetOfficeServices
{
    public class TreatmentService : Service<Treatment>
    {
        public TreatmentService() : base((ITreatmentRepository)Injector.GetRepositoryInstance("ITreatmentRepository"))
        {
        }

        public List<Treatment> GetTreatmentByAnimalId(int animalId)
        {
            return GetAll().Where(m => m.AnimalId == animalId).ToList();
        }

        public List<Treatment> GetTreatmentByVetOfficeId(int vetOfficeId)
        {
            return GetAll().Where(m => m.VetOfficeId == vetOfficeId).ToList();
        }
    }
}
