using Frontend.ViewModel.AssociationViewModels;
using System.Windows;

namespace Frontend.View
{
    public partial class DonationsView : Window
    {
        public DonationsView()
        {
            InitializeComponent();
            DataContext = new DonationsViewModel();
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
