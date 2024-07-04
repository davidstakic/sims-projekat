using Backend.Models.Enums;
using Backend.Models.UserModels;
using Backend.Services.UserServices;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Frontend.ViewModel.ModelViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private ProfileService _profileService;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _email;
        private DateTime _birthDate;
        private string _username;
        private string _password;

        public int Id { get; set; }
        public string FirstName
        {
            get => _firstName;
            set { if (_firstName != value) { _firstName = value; OnPropertyChanged("FirstName"); } }
        }
        public string LastName
        {
            get => _lastName;
            set { if (_lastName != value) { _lastName = value; OnPropertyChanged("LastName"); } }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set { if (_phoneNumber != value) { _phoneNumber = value; OnPropertyChanged("PhoneNumber"); } }
        }
        public string Email
        {
            get => _email;
            set { if (_email != value) { _email = value; OnPropertyChanged("Email"); } }
        }
        public DateTime BirthDate
        {
            get => _birthDate;
            set { if (_birthDate != value) { _birthDate = value; OnPropertyChanged("BirthDate"); } }
        }
        public Gender Gender { get; set; }
        public string Username
        {
            get => _username;
            set { if (_username != value) { _username = value; OnPropertyChanged("Username"); } }
        }
        public string Password
        {
            get => _password;
            set { if (_password != value) { _password = value; OnPropertyChanged("Password"); } }
        }
        public int ProfileId { get; set; }
        public int AssociationId { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public bool IsMale { get; set; }
        public bool IsFemale {  get; set; }
        public bool IsOther { get; set; }

        public UserViewModel(int id, string firstName, string lastName, string phoneNumber, string email, DateTime birthDate, Gender gender, int profileId, int associationId, ProfileService profileService)
        {
            _profileService = profileService;
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            ProfileId = profileId;
            AssociationId = associationId;
            Profile profile = _profileService.GetById(ProfileId);
            Username = profile.Username;
            Password = profile.Password;
            IsMale = Gender == Gender.Male ? true : false;
            IsFemale = Gender == Gender .Female ? true : false;
            IsOther = Gender == Gender .Other ? true : false;
        }
        public UserViewModel(ProfileService profileService)
        {
            _profileService = profileService;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
