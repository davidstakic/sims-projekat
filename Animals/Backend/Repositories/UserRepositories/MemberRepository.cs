using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Repositories.UserRepositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(string filePath) : base(filePath)
        {
        }
        public Member GetMemberByProfileId(int profileId)
        {
            return GetAll().FirstOrDefault(m => m.ProfileId == profileId)!;
        }

        public Member GetMemberByAssociationId(int associationId)
        {
            return GetAll().FirstOrDefault(m => m.AssociationId == associationId)!;
        }
    }
}
