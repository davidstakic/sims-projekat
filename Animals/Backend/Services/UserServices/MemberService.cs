using Backend.Configuration;
using Backend.Models.UserModels;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Services.UserServices
{
    public class MemberService : Service<Member>
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService() : base((IMemberRepository)Injector.GetRepositoryInstance("IMemberRepository"))
        {
            _memberRepository = (IMemberRepository)Injector.GetRepositoryInstance("IMemberRepository");
        }

        public Member GetMemberByLikeId(int likeUserId)
        {
            return _memberRepository.GetMemberByLikeId(likeUserId);
        }

        public Member GetMemberByCommentId(int commentUserId)
        {
            return _memberRepository.GetMemberByCommentId(commentUserId);
        }
    }
}
