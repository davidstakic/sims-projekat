using Backend.Models.VetOfficeModels;

namespace Backend.Repositories.Interfaces.VetOfficeInterfaces
{
    public interface ITreatmentRepository : IRepository<Treatment>
    {
        IEnumerable<Treatment> GetTreatmentByAnimalId(int animalId);
        IEnumerable<Treatment> GetTreatmentByVetOfficeId(int vetOfficeId);
    }
}
