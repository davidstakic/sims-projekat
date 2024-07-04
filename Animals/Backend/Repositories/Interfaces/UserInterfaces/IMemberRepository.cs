using Backend.Models.UserModels;

namespace Backend.Repositories.Interfaces.UserInterfaces
{
    public interface IMemberRepository : IRepository<Member>
    {
        Member GetMemberByLikeId(int likeUserId);
        Member GetMemberByCommentId(int commentUserId);
    }
}
