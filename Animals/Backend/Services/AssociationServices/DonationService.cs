using Backend.Configuration;
using Backend.Models.AssociationModels;
using Backend.Repositories.Interfaces.AssociationInterfaces;

namespace Backend.Services.AssociationServices
{
    public class DonationService : Service<Donation>
    {
        public DonationService() : base((IDonationRepository)Injector.GetRepositoryInstance("IDonationRepository"))
        {
        }
    }
}
