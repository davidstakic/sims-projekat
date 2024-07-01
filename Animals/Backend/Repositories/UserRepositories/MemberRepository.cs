using Backend.Repositories.Interfaces.UserInterfaces;

namespace Backend.Repositories.UserRepositories
{
    public class MemberRepository : UserRepository, IMemberRepository
    {
        public MemberRepository(string filePath) : base(filePath)
        {
        }
    }
}
