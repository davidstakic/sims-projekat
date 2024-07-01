using System.Windows;

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
            this.DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
