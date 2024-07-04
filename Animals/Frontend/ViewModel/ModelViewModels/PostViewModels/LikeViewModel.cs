using Backend.Models.PostModels;
using Backend.Models.UserModels;
using Backend.Services.UserServices;

namespace Frontend.ViewModel.ModelViewModels.PostViewModels
{
    public class LikeViewModel
    {
        private MemberService _memberService = new MemberService();

        public Like Like { get; set; }
        public Member Member { get; set; }
        public string FullName => $"{Member.FirstName} {Member.LastName}";

        public LikeViewModel(Like like)
        {
            Like = like;
            Member = _memberService.GetMemberByLikeId(like.UserId);
        }
    }
}
