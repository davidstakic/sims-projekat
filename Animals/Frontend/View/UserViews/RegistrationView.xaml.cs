using Backend.Models.Enums;
using Backend.Models.UserModels;
using Backend.Services.UserServices;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class RegistrationView : Window
    {
        public RegistrationView()
        {
            InitializeComponent();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Member member = new Member();
            member.FirstName = FirstNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(member.FirstName)) return;
            member.LastName = LastNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(member.LastName)) return;
            member.Email = EmailTextBox.Text;
            if (string.IsNullOrWhiteSpace(member.Email)) return;
            member.PhoneNumber = PhoneNumberTextBox.Text;
            if (string.IsNullOrWhiteSpace(member.PhoneNumber)) return;
            DateTime? birthDate = BirthDatePicker.SelectedDate;
            if (birthDate == null) return;
            member.BirthDate = DateOnly.FromDateTime(birthDate.Value);
            if (MaleRadioButton.IsChecked == true) member.Gender = Gender.Male;
            else if (FemaleRadioButton.IsChecked == true) member.Gender = Gender.Female;
            else if (OtherRadioButton.IsChecked == true) member.Gender = Gender.Other;
            else return;

            string username = UsernameTextBox.Text;
            if (string.IsNullOrWhiteSpace(username)) return;
            string password = PasswordBox.Password;
            if (string.IsNullOrWhiteSpace(password)) return;
            Profile profile = new Profile(username, password, DateTime.Now);
            new ProfileService().Create(profile);

            member.ProfileId = profile.Id;
            member.IsBlacklisted = false;
            member.Status = Status.Waiting;
            member.AssociationId = 202;

            new MemberService().Create(member);
            new PrintMessageView("Succesfully registered!").Show();
            new MainWindow().Show();
            Close();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordText.Visibility = string.IsNullOrEmpty(PasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
