using Backend.Services.PostServices;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View;
public partial class LikesView : Window
{
    public LikesView(int userId, int postId, LikeService likeService)
    {
        InitializeComponent();
        DataContext = new LikesViewModel(userId, postId, likeService);

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
