using Frontend.View;
using System.Windows;
using System.Windows.Controls;

namespace Frontend
{
    public partial class PostsView : Window
    {
        public PostsView()
        {
            InitializeComponent();
            DataContext = new PostsViewModel();
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PostBorder_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is Border border && border.DataContext is PostViewModel postViewModel)
            {
                var postDetailView = new PostDetailView(postViewModel);
                postDetailView.ShowDialog();
            }
        }
    }
}
