using Backend.Models.VetOfficeModels;

namespace Backend.Repositories.Interface.IRepositoryVetOffice
{
    public interface ITreatmentRepository : IRepository<Treatment>
    {
        IEnumerable<Treatment> GetMessageByAnimalId(int animalId);
        IEnumerable<Treatment> GetMessageByVetOfficeId(int vetOfficeId);
    }
}
