using Backend.Services.AnimalServices;
using Backend.Services.PostServices;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View;
public partial class OptionsView : Window
{
    public OptionsView(int userId, int postId, PostService postService, LikeService likeService, CommentService commentService, AnimalService animalService, SpecieService specieService, PostDetailView postDetailedView)
    {
        InitializeComponent();
        DataContext = new OptionsViewModel(userId, postId, postService, likeService, commentService, animalService, specieService, postDetailedView);
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

    private void Update_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Likes_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Comments_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Adopt_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
