using Backend.Models.UserModels;
using Frontend.View;
using System.Windows;
using System.Windows.Controls;

namespace Frontend
{
    public partial class PostsView : Window
    {
        private Member currentMember { get; set; }
        public PostsView(Member currentMember)
        {
            InitializeComponent();
            DataContext = new PostsViewModel();
            this.currentMember = currentMember;
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
            if (sender is Border border && border.DataContext is PostDetailViewModel postViewModel)
            {
                new PostDetailView(postViewModel).ShowDialog();
            }
        }
    }
}
