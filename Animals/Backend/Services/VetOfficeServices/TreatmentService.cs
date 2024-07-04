using Backend.Configuration;
using Backend.Models.VetOfficeModels;
using Backend.Repositories.Interfaces.VetOfficeInterfaces;

namespace Backend.Services.VetOfficeServices
{
    public class TreatmentService : Service<Treatment>
    {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentService() : base((ITreatmentRepository)Injector.GetRepositoryInstance("ITreatmentRepository"))
        {
            _treatmentRepository = (ITreatmentRepository)Injector.GetRepositoryInstance("ITreatmentRepository");
        }

        public List<Treatment> GetTreatmentByAnimalId(int animalId)
        {
            return _treatmentRepository.GetTreatmentByAnimalId(animalId).ToList();
        }
    }
}
