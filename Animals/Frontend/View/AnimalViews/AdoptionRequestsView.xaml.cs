using System.Windows;
using System.Windows.Input;
using Backend.Services.PostServices;
using Frontend.ViewModel.ModelViewModels.AnimalViewModels;

namespace Frontend.View
{
    public partial class AdoptionRequestsView : Window
    {
        public AdoptionRequestsView(PostService postService, CommentService commentService, LikeService likeService)
        {
            InitializeComponent();
            DataContext = new AdoptionRequestsViewModel(postService, commentService, likeService);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
