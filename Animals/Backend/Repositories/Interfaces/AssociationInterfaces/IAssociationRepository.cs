using Backend.Models.AssociationModels;

namespace Backend.Repositories.Interfaces.AssociationInterfaces
{
    public interface IAssociationRepository : IRepository<Association>
    {
        IEnumerable<Association> GetAssociationByVetOfficeIds(int vetOfficeId);
    }
}
