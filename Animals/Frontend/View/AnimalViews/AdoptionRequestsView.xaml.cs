using System.Windows;
using System.Windows.Input;
using Frontend.ViewModel.ModelViewModels.AnimalViewModels;

namespace Frontend.View
{
    public partial class AdoptionRequestsView : Window
    {
        public AdoptionRequestsView()
        {
            InitializeComponent();
            DataContext = new AdoptionRequestsViewModel();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
