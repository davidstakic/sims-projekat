using System.Windows;
using Frontend.ViewModel.ModelViewModels.PostViewModels;

namespace Frontend.View
{
    public partial class PostRequestsView : Window
    {
        public PostRequestsView()
        {
            InitializeComponent();
            DataContext = new PostRequestsViewModel();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
