using System.Windows;

namespace Frontend.View
{
    public partial class PostDetailView : Window
    {
        public PostDetailView(PostViewModel postViewModel)
        {
            InitializeComponent();
            DataContext = postViewModel;
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
