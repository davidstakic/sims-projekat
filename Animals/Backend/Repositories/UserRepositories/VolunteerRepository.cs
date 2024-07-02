using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Repositories.UserRepositories
{
    public class VolunteerRepository : Repository<Volunteer>, IVolunteerRepository
    {
        public VolunteerRepository(string filePath) : base(filePath)
        {
        }

        public Volunteer GetVolunteerByProfileId(int profileId)
        {
            return GetAll().FirstOrDefault(m => m.ProfileId == profileId)!;
        }

        public Volunteer GetVolunteerByAssociationId(int associationId)
        {
            return GetAll().FirstOrDefault(m => m.AssociationId == associationId)!;
        }
    }
}
