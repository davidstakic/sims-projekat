using Backend.Models.AnimalModels;
using Backend.Models.UserModels;
using Backend.Services.UserServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Frontend.ViewModel.UserViewModels
{
    public class MembersViewModel : INotifyPropertyChanged
    {
        private readonly MemberService _memberService;
        private ObservableCollection<Member>? _members;

        public ObservableCollection<Member>? Members
        {
            get { return _members; }
            set
            {
                _members = value;
                OnPropertyChanged(nameof(Members));
            }
        }

        public RelayCommand<Member> BlacklistCommand { get; }
        public RelayCommand<Member> UnblacklistCommand { get; }

        public MembersViewModel()
        {
            _memberService = new MemberService();
            LoadMembers();

            BlacklistCommand = new RelayCommand<Member>(BlacklistMember);
            UnblacklistCommand = new RelayCommand<Member>(UnblacklistMember);
        }

        public void LoadMembers()
        {
            var allMembers = _memberService.GetAll();
            Members = new ObservableCollection<Member>(allMembers);
        }

        private void BlacklistMember(Member? member)
        {
            // Set IsBlacklisted to true
            member.IsBlacklisted = true;

            // Update the member in the database
            _memberService.Update(member);
            LoadMembers();
        }

        private void UnblacklistMember(Member? member)
        {
            // Set IsBlacklisted to false
            member.IsBlacklisted = false;

            // Update the member in the database
            _memberService.Update(member);
            LoadMembers();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
