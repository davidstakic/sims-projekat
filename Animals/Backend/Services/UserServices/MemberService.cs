using Backend.Configuration;
using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Services.UserServices
{
    public class MemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService() : base()
        {
            _memberRepository = (IMemberRepository)Injector.GetRepositoryInstance("IMemberRepository");
        }
    }
}
