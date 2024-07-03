using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;
using Frontend.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend
{
    public partial class PostsView : Window
    {
        private Member currentMember { get; set; }
        private LikeService likeService { get; set; }
        private CommentService commentService { get; set; }
        private AnimalService animalService { get; set; }
        private SpecieService specieService { get; set; }
        public PostsView(Member currentMember, PostService postService, LikeService likeService, CommentService commentService, AnimalService animalService, SpecieService specieService)
        {
            InitializeComponent();
            DataContext = new PostsViewModel(currentMember, postService, likeService, commentService, animalService, specieService);
            this.currentMember = currentMember;
            this.likeService = likeService;
            this.commentService = commentService;
            this.animalService = animalService;
            this.specieService = specieService;
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
    }
}
