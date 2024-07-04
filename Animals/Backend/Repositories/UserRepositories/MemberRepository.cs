using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Repositories.UserRepositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(string filePath) : base(filePath)
        {
        }

        public Member GetMemberByLikeId(int likeUserId)
        {
            return GetAll().FirstOrDefault(m => m.Id == likeUserId)!;
        }

        public Member GetMemberByCommentId(int commentUserId)
        {
            return GetAll().FirstOrDefault(m => m.Id == commentUserId)!;
        }
    }
}
