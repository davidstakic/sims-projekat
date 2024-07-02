using Backend.Models.UserModels;
using Frontend.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend
{
    public partial class PostsView : Window
    {
        private Member currentMember { get; set; }
        public PostsView(Member currentMember)
        {
            InitializeComponent();
            DataContext = new PostsViewModel(currentMember);
            this.currentMember = currentMember;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PostBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border && border.DataContext is PostDetailViewModel postViewModel)
            {
                new PostDetailView(postViewModel).ShowDialog();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            new CreatePostView(currentMember).ShowDialog();
        }
    }
}
