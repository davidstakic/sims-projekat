using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class PostDetailView : Window
    {
        public PostDetailView(PostDetailViewModel postViewModel)
        {
            InitializeComponent();
            DataContext = postViewModel;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
