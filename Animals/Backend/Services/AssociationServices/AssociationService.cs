using Backend.Configuration;
using Backend.Models.AssociationModels;
using Backend.Repositories.Interfaces.AssociationInterfaces;

namespace Backend.Services.AssociationServices
{
    public class AssociationService : Service<Association>
    {
        private readonly IAssociationRepository _associationRepository;
        public AssociationService() : base((IAssociationRepository)Injector.GetRepositoryInstance("IAssociationRepository"))
        {
            _associationRepository = (IAssociationRepository)Injector.GetRepositoryInstance("IAssociationRepository");
        }
    }
}
