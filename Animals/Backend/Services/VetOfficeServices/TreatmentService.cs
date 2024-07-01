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
    }
}
