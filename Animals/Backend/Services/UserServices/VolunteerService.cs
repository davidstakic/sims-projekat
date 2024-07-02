using Backend.Configuration;
using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Services.UserServices
{
    public class VolunteerService : Service<Volunteer>
    {
        public VolunteerService() : base((IVolunteerRepository) Injector.GetRepositoryInstance("IVolunteerRepository"))
        {
        }
    }
}
