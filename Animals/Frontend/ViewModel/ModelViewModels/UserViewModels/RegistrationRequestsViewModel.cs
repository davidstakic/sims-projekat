using Backend.Models.UserModels;
using Backend.Models.Enums;
using Backend.Services.UserServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
            // Logic to accept the member, e.g., updating status in the database
            member.Status = Status.Accepted;
            _memberService.Update(member); // Assuming there's an Update method in MemberService
            WaitingMembers.Remove(member);
            MessageBox.Show($"Member {member.FirstName} {member.LastName} has been accepted.");
        }

        private void RejectMember(Member? member)
        {
            // Logic to reject the member, e.g., updating status in the database
            member.Status = Status.Rejected;
            _memberService.Update(member); // Assuming there's an Update method in MemberService
            WaitingMembers.Remove(member);
            MessageBox.Show($"Member {member.FirstName} {member.LastName} has been rejected.");
        }
    }
}
