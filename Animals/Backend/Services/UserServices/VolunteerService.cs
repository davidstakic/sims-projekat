using Backend.Configuration;
using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Services.UserServices
{
    public class VolunteerService : Service<Volunteer>
    {
        private readonly IVolunteerRepository _volunteerRepository;
        public VolunteerService() : base((IVolunteerRepository) Injector.GetRepositoryInstance("IVolunteerRepository"))
        {
            _volunteerRepository = (IVolunteerRepository)Injector.GetRepositoryInstance("IVolunteerRepository");
        }
    }
}
