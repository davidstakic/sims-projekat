using Backend.Models.AssociationModels;

namespace Backend.Repositories.Interface.IAssociationRepository
{
    public interface IAssociationRepository
    {
        IEnumerable<Association> GetAssociationByVetOfficeIds(int vetOfficeId);
    }
}
