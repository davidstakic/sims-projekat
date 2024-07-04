using Backend.Models.Enums;
using Backend.Models.UserModels;
using Backend.Services.UserServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Frontend.View;
using System.Collections.ObjectModel;
using System.Windows;

namespace Frontend.ViewModel.UserViewModels
{
    public class RegistrationRequestsViewModel : ObservableObject
    {
        private readonly MemberService _memberService;

        public ObservableCollection<Member> WaitingMembers { get; }
        public RelayCommand<Member> AcceptCommand { get; }
        public RelayCommand<Member> RejectCommand { get; }

        public RegistrationRequestsViewModel()
        {
            _memberService = new MemberService();
            var allMembers = _memberService.GetAll();
            WaitingMembers = new ObservableCollection<Member>(allMembers.Where(m => m.Status == Status.Waiting));

            AcceptCommand = new RelayCommand<Member>(AcceptMember);
            RejectCommand = new RelayCommand<Member>(RejectMember);
        }

        private void AcceptMember(Member? member)
        {
            member.Status = Status.Accepted;
            _memberService.Update(member);
            WaitingMembers.Remove(member);
            new PrintMessageView($"Member {member.FirstName} {member.LastName} has been accepted.").Show();
        }

        private void RejectMember(Member? member)
        {
            member.Status = Status.Rejected;
            _memberService.Update(member);
            WaitingMembers.Remove(member);
            new PrintMessageView($"Member {member.FirstName} {member.LastName} has been rejected.").Show();
        }
    }
}
