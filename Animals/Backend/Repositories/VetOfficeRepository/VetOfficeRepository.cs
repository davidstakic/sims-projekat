using Backend.Models.VetOfficeModels;
using Backend.Repositories.Interface.IRepositoryVetOffice;

namespace Backend.Repositories.VetOfficeRepository
{
    public class VetOfficeRepository : Repository<VetOffice>, IVetOfficeRepository
    {
        public VetOfficeRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<VetOffice> IVetOfficeRepository.GetVetOfficeBySenderId(int associationId)
        {
            return GetAll().Where(m => m.AssociationIds.Contains(associationId));
        }
    }
}
