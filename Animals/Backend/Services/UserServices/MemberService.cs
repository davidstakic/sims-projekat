using Backend.Configuration;
using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Services.UserServices
{
    public class MemberService : Service<Member>
    {
        public MemberService() : base((IMemberRepository)Injector.GetRepositoryInstance("IMemberRepository"))
        {
        }

        public Member GetMemberByLikeId(int likeUserId)
        {
            return GetAll().FirstOrDefault(m => m.Id == likeUserId)!;
        }
    }
}
