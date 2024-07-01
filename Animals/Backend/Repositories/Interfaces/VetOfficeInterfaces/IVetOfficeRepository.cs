using Backend.Models.VetOfficeModels;

namespace Backend.Repositories.Interfaces.VetOfficeInterfaces
{
    public interface IVetOfficeRepository : IRepository<VetOffice>
    {
        IEnumerable<VetOffice> GetVetOfficeBySenderId(int associationId);
    }
}
