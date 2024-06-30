using Backend.Models.VetOfficeModels;

namespace Backend.Repositories.Interface.IRepositoryVetOffice
{
    public interface IVetOfficeRepository : IRepository<VetOffice>
    {
        IEnumerable<VetOffice> GetVetOfficeBySenderId(int associationId);
    }
}
