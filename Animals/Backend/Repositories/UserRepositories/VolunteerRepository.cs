using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Repositories.UserRepositories
{
    public class VolunteerRepository : UserRepository, IVolunteerRepository
    {
        public VolunteerRepository(string filePath) : base(filePath)
        {
        }
    }
}
