using Backend.Models.Enums;
using Backend.Models.UserModels;
using Backend.Services.UserServices;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class MemberUpdateView : Window
    {
        private Member _currentMember;

        public MemberUpdateView(Member currentMember)
        {
            InitializeComponent();
            _currentMember = currentMember;
            FirstNameTextBox.Text = currentMember.FirstName;
            LastNameTextBox.Text = currentMember.LastName;
            EmailTextBox.Text = currentMember.Email;
            PhoneNumberTextBox.Text = currentMember.PhoneNumber;
            DateOnly memberBirthDate = currentMember.BirthDate;
            BirthDatePicker.SelectedDate = new DateTime(memberBirthDate.Year, memberBirthDate.Month, memberBirthDate.Day, 12, 0, 0);
            if (currentMember.Gender == Gender.Male) MaleRadioButton.IsChecked = true;
            else if (currentMember.Gender == Gender.Female) FemaleRadioButton.IsChecked = true;
            else if (currentMember.Gender == Gender.Other) OtherRadioButton.IsChecked = true;
            Profile profile = new ProfileService().GetById(currentMember.ProfileId);
            UsernameTextBox.Text = profile.Username;
            PasswordBox.Text = profile.Password;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            _currentMember.FirstName = FirstNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(_currentMember.FirstName)) return;
            _currentMember.LastName = LastNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(_currentMember.LastName)) return;
            _currentMember.Email = EmailTextBox.Text;
            if (string.IsNullOrWhiteSpace(_currentMember.Email)) return;
            _currentMember.PhoneNumber = PhoneNumberTextBox.Text;
            if (string.IsNullOrWhiteSpace(_currentMember.PhoneNumber)) return;
            DateTime? birthDate = BirthDatePicker.SelectedDate;
            if (birthDate == null) return;
            _currentMember.BirthDate = DateOnly.FromDateTime(birthDate.Value);
            if (MaleRadioButton.IsChecked == true) _currentMember.Gender = Gender.Male;
            else if (FemaleRadioButton.IsChecked == true) _currentMember.Gender = Gender.Female;
            else if (OtherRadioButton.IsChecked == true) _currentMember.Gender = Gender.Other;
            else return;

            Profile profile = new ProfileService().GetById(_currentMember.ProfileId);
            string username = UsernameTextBox.Text;
            if (string.IsNullOrWhiteSpace(username)) return;
            string password = PasswordBox.Text;
            if (string.IsNullOrWhiteSpace(password)) return;
            profile.Username = username;
            profile.Password = password;
            new ProfileService().Update(profile);

            _currentMember.ProfileId = _currentMember.ProfileId;
            _currentMember.IsBlacklisted = _currentMember.IsBlacklisted;
            _currentMember.Status = _currentMember.Status;
            _currentMember.AssociationId = _currentMember.AssociationId;

            new MemberService().Update(_currentMember);
            MessageBox.Show("Succesfully updated!");
            Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
