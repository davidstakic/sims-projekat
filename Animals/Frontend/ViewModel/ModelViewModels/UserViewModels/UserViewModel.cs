using System.ComponentModel;
using System.Runtime.CompilerServices;
using Backend.Models.Enums;
using Backend.Models.UserModels;

namespace Frontend.ViewModel.ModelViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _email;
        private DateOnly _birthDate;
        private Gender _gender;

        public int Id { get; set; }

        public string FirstName
        {
            get => _firstName;
            set { if (_firstName != value) { _firstName = value; OnPropertyChanged(); } }
        }

        public string LastName
        {
            get => _lastName;
            set { if (_lastName != value) { _lastName = value; OnPropertyChanged(); } }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { if (_phoneNumber != value) { _phoneNumber = value; OnPropertyChanged(); } }
        }

        public string Email
        {
            get => _email;
            set { if (_email != value) { _email = value; OnPropertyChanged(); } }
        }

        public DateOnly BirthDate
        {
            get => _birthDate;
            set { if (_birthDate != value) { _birthDate = value; OnPropertyChanged(); } }
        }

        public Gender Gender
        {
            get => _gender;
            set { if (_gender != value) { _gender = value; OnPropertyChanged(); } }
        }

        public int ProfileId { get; set; }

        public int AssociationId { get; set; }

        public UserViewModel() { }

        public UserViewModel(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            PhoneNumber = user.PhoneNumber;
            Email = user.Email;
            BirthDate = user.BirthDate;
            Gender = user.Gender;
            ProfileId = user.ProfileId;
            AssociationId = user.AssociationId;
        }

        public UserViewModel(UserViewModel user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            PhoneNumber = user.PhoneNumber;
            Email = user.Email;
            BirthDate = user.BirthDate;
            Gender = user.Gender;
            ProfileId = user.ProfileId;
            AssociationId = user.AssociationId;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
