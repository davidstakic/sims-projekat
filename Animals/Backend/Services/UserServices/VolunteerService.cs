using Backend.Configuration;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Services.UserServices
{
    public class VolunteerService
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public VolunteerService() : base()
        {
            _volunteerRepository = (IVolunteerRepository)Injector.GetRepositoryInstance("IVolunteerRepository");
        }
    }
}
