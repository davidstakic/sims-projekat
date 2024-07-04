using Backend.Models.Enums;
using Backend.Models.UserModels;
using Backend.Services.UserServices;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class MemberUpdateView : Window
    {
        private Member currentMember { get; set; }
        public MemberUpdateView(Member currentMember)
        {
            InitializeComponent();
            this.currentMember = currentMember;
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
            PasswordBox.Password = profile.Password;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            currentMember.FirstName = FirstNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(currentMember.FirstName)) return;
            currentMember.LastName = LastNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(currentMember.LastName)) return;
            currentMember.Email = EmailTextBox.Text;
            if (string.IsNullOrWhiteSpace(currentMember.Email)) return;
            currentMember.PhoneNumber = PhoneNumberTextBox.Text;
            if (string.IsNullOrWhiteSpace(currentMember.PhoneNumber)) return;
            DateTime? birthDate = BirthDatePicker.SelectedDate;
            if (birthDate == null) return;
            currentMember.BirthDate = DateOnly.FromDateTime(birthDate.Value);
            if (MaleRadioButton.IsChecked == true) currentMember.Gender = Gender.Male;
            else if (FemaleRadioButton.IsChecked == true) currentMember.Gender = Gender.Female;
            else if (OtherRadioButton.IsChecked == true) currentMember.Gender = Gender.Other;
            else return;

            Profile profile = new ProfileService().GetById(currentMember.ProfileId);
            string username = UsernameTextBox.Text;
            if (string.IsNullOrWhiteSpace(username)) return;
            string password = PasswordBox.Password;
            if (string.IsNullOrWhiteSpace(password)) return;
            profile.Username = username;
            profile.Password = password;
            new ProfileService().Update(profile);

            currentMember.ProfileId = currentMember.ProfileId;
            currentMember.IsBlacklisted = currentMember.IsBlacklisted;
            currentMember.Status = currentMember.Status;
            currentMember.AssociationId = currentMember.AssociationId;

            new MemberService().Update(currentMember);
            MessageBox.Show("Succesfully updated!");
            Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
