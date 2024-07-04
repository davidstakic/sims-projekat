using Backend.Configuration;
using Backend.Models.VetOfficeModels;
using Backend.Repositories.Interfaces.VetOfficeInterfaces;

namespace Backend.Services.VetOfficeServices
{
    public class VetOfficeService : Service<VetOffice>
    {
        private readonly IVetOfficeRepository _vetOfficeRepository;
        public VetOfficeService() : base((IVetOfficeRepository)Injector.GetRepositoryInstance("IVetOfficeRepository"))
        {
            _vetOfficeRepository = (IVetOfficeRepository)Injector.GetRepositoryInstance("IVetOfficeRepository");
        }
    }
}
