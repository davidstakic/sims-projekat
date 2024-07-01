using Backend.Models.AssociationModels;
using Backend.Repositories.Interfaces.AssociationInterfaces;

namespace Backend.Repositories.AssociationRepositories
{
    public class AssociationRepository : Repository<Association>, IAssociationRepository
    {
        public AssociationRepository(string filePath) : base(filePath)
        {
        }

        IEnumerable<Association> IAssociationRepository.GetAssociationByVetOfficeIds(int vetOfficeId)
        {
            return GetAll().Where(m => m.VetOfficeIds.Contains(vetOfficeId));
        }
    }
}
