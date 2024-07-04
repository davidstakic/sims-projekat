using Backend.Models.Enums;
using Backend.Models.UserModels;
using Backend.Services.UserServices;
using Frontend.View;
using System.Text.RegularExpressions;

namespace Frontend.ViewModel.ModelViewModels.UserViewModels
{
    public class VolunteerViewModel : UserViewModel
    {
        private bool _isAdmin;
        private VolunteerService _volunteerService;
        private ProfileService _profileService;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                if (value != _isAdmin)
                {
                    _isAdmin = value;
                    OnPropertyChanged("IsAdmin");
                }
            }
        }

        public VolunteerViewModel(VolunteerService volunteerService, ProfileService profileService) : base(profileService)
        {
            _volunteerService = volunteerService;
            _profileService = profileService;
            BirthDate = DateTime.Today;
        }
        public VolunteerViewModel(Volunteer volunteer, VolunteerService volunteerService, ProfileService profileService) : base(volunteer.Id, volunteer.FirstName, volunteer.LastName, volunteer.PhoneNumber, volunteer.Email, volunteer.BirthDate.ToDateTime(TimeOnly.MinValue), volunteer.Gender, volunteer.ProfileId, volunteer.Id, profileService)
        {
            _volunteerService = volunteerService;
            _profileService = profileService;
            IsAdmin = volunteer.IsAdmin;
        }

        public void CreateVolunteer()
        {
            if (!IsValid)
            {
                PrintValidationErrors();
                return;
            }
            try
            {
                if (_profileService.DoesUsernameExist(Username))
                {
                    new PrintMessageView("Given username already exists.").Show();
                    return;
                }
                Profile newProfile = new Profile(-1, Username, Password, DateTime.Now);
                _profileService.Create(newProfile);

                Volunteer newVolunter = new Volunteer(Id, FirstName, LastName, PhoneNumber, Email, DateOnly.FromDateTime(BirthDate), Gender, ProfileId, AssociationId, IsAdmin);
                if (IsMale) { newVolunter.Gender = Gender.Male; }
                if (IsFemale) { newVolunter.Gender = Gender.Female; }
                if (IsOther) { newVolunter.Gender = Gender.Other; }
                newVolunter.ProfileId = newProfile.Id;
                _volunteerService.Create(newVolunter);

                new PrintMessageView("Successfully created volunteer.").Show();
            }
            catch (Exception ex)
            {
                new PrintMessageView($"Failed to create volunteer: {ex.Message}").Show();
            }
        }

        public void UpdateVolunteer()
        {
            if (!IsValid)
            {
                PrintValidationErrors();
                return;
            }
            try
            {
                Volunteer updatedVolunteer = new Volunteer(Id, FirstName, LastName, PhoneNumber, Email, DateOnly.FromDateTime(BirthDate), Gender, ProfileId, AssociationId, IsAdmin);
                if (IsMale) { updatedVolunteer.Gender = Gender.Male; }
                if (IsFemale) { updatedVolunteer.Gender = Gender.Female; }
                if (IsOther) { updatedVolunteer.Gender = Gender.Other; }
                _volunteerService.Update(updatedVolunteer);

                Profile updatedProfile = _profileService.GetById(ProfileId);
                updatedProfile.Username = Username;
                updatedProfile.Password = Password;
                _profileService.Update(updatedProfile);

                new PrintMessageView("Successfully updated volunteer.").Show();
            }
            catch (Exception ex)
            {
                new PrintMessageView($"Failed to update volunteer: {ex.Message}").Show();
            }
        }

        private void PrintValidationErrors()
        {
            foreach (var property in _validatedProperties)
            {
                string error = this[property];
                if (!string.IsNullOrEmpty(error))
                {
                    new PrintMessageView(error).Show();
                    break;
                }
            }
        }

        public string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case "FirstName":
                        if (string.IsNullOrWhiteSpace(FirstName))
                            return "First name is required.";
                        break;
                    case "LastName":
                        if (string.IsNullOrWhiteSpace(LastName))
                            return "Last name is required.";
                        break;
                    case "PhoneNumber":
                        if (string.IsNullOrWhiteSpace(PhoneNumber))
                            return "Phone number is required.";
                        if (!Regex.IsMatch(PhoneNumber, @"^\d{9,10}$"))
                            return "Phone number must be 9 or 10 digits.";
                        break;
                    case "Email":
                        if (string.IsNullOrWhiteSpace(Email))
                            return "Email is required.";
                        if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                            return "Email is not in a valid format.";
                        break;
                    case "BirthDate":
                        if (BirthDate > DateTime.Today)
                            return "Birth date must be a date from the past.";
                        break;
                    case "Username":
                        if (string.IsNullOrEmpty(Username))
                            return "Username is required.";
                        break;
                    case "Password":
                        if (string.IsNullOrEmpty(Password))
                            return "Password is required.";
                        break;
                }
                return string.Empty;
            }
        }

        private readonly string[] _validatedProperties = { "FirstName", "LastName", "PhoneNumber", "Email", "BirthDate", "Username", "Password" };

        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (!string.IsNullOrEmpty(this[property]))
                        return false;
                }

                return true;
            }
        }

        public string Error => string.Empty;
    }
}
