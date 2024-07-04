using Backend.Models.PostModels;
using Backend.Models.UserModels;
using Backend.Services.UserServices;

namespace Frontend.ViewModel.ModelViewModels.PostViewModels
{
    public class CommentViewModel
    {
        private MemberService _memberService = new MemberService();

        public Comment Comment { get; set; }
        public Member Member { get; set; }
        public string FullName => $"{Member.FirstName} {Member.LastName} said:";

        public CommentViewModel(Comment comment)
        {
            Comment = comment;
            Member = _memberService.GetMemberByCommentId(comment.UserId);
        }
    }
}
