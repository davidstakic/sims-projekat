using Backend.Models.AssociationModels;
using Backend.Models.UserModels;
using Backend.Services.AssociationServices;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class DonationView : Window
    {
        private Member _currentMember;

        public DonationView(Member currentMember)
        {
            InitializeComponent();
            _currentMember = currentMember;
        }

        private void Donate_Click(object sender, RoutedEventArgs e)
        {
            int amount;
            bool success = int.TryParse(AmountTextBox.Text, out amount);
            if (!success || amount < 0)
            {
                MessageBox.Show("Please enter a valid number.");
                return;
            }
            DonationService donationService = new DonationService();
            donationService.Create(new Donation(DateTime.Now, amount, _currentMember.Id, -1, _currentMember.AssociationId));
            Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
