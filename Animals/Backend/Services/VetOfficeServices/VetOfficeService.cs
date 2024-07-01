using Backend.Configuration;
using Backend.Models.VetOfficeModels;
using Backend.Repositories.Interfaces.VetOfficeInterfaces;

namespace Backend.Services.VetOfficeServices
{
    public class VetOfficeService : Service<VetOffice>
    {
        public VetOfficeService() : base((IVetOfficeRepository)Injector.GetRepositoryInstance("IVetOfficeRepository"))
        {
        }
    }
}
