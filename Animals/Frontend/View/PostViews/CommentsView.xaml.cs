using Backend.Services.PostServices;
using Frontend.ViewModel.ModelViewModels.PostViewModels;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View;
public partial class CommentsView : Window
{
    public CommentsView(int userId, int postId, CommentService commentService)
    {
        InitializeComponent();
        DataContext = new CommentsViewModel(userId, postId, commentService);
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
