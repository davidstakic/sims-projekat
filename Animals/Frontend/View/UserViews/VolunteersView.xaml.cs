using Backend.Services.PostServices;
using Backend.Services.UserServices;
using Frontend.ViewModel.ModelViewModels.UserViewModels;
using Frontend.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class VolunteersView : Window
    {
        private VolunteerService _volunteerService;
        private ProfileService _profileService;
        private PostService _postService;
        private CommentService _commentService;
        private LikeService _likeService;

        public VolunteersView(VolunteerService volunteerService, ProfileService profileService, PostService postService, CommentService commentService, LikeService likeService)
        {
            InitializeComponent();

            _volunteerService = volunteerService;
            _profileService = profileService;
            _postService = postService;
            _commentService = commentService;
            _likeService = likeService;
            DataContext = new VolunteerListViewModel(_volunteerService, _profileService);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new VolunteerRegistrationView(_volunteerService, _profileService).Show();
        }

        private void EditImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is VolunteerViewModel volunteerViewModel)
            {
                var updateWindow = new VolunteerUpdateView(volunteerViewModel);
                updateWindow.Show();
            }
        }

        private void DeleteImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is VolunteerViewModel volunteerViewModel)
            {
                var destructiveActionView = new ActionView("Are you sure you want to delete?");

                destructiveActionView.OnYesAction = () =>
                {
                    _volunteerService.Delete(volunteerViewModel.Id);
                    _profileService.Delete(volunteerViewModel.ProfileId);
                    DeleteUserPosts(volunteerViewModel.Id);
                    DeleteUserComments(volunteerViewModel.Id);
                    DeleteUserLikes(volunteerViewModel.Id);
                    new PrintMessageView("Successfuly deleted volunteer.").Show();
                };

                destructiveActionView.ShowDialog();
            }
        }

        private void DeleteUserPosts(int userId)
        {
            var userPosts = _postService.GetPostByUserId(userId);
            foreach (var post in userPosts)
            {
                _postService.Delete(post.Id);
                DeletePostComments(post.Id);
                DeletePostLikes(post.Id);
            }
        }

        private void DeleteUserComments(int userId)
        {
            var userComments = _commentService.GetCommentByUserId(userId);
            foreach (var comment in userComments)
            {
                _commentService.Delete(comment.Id);
            }
        }

        private void DeleteUserLikes(int userId)
        {
            var userLikes = _likeService.GetLikeByUserId(userId);
            foreach (var like in userLikes)
            {
                _likeService.Delete(like.Id);
            }
        }

        private void DeletePostComments(int postId)
        {
            var postComments = _commentService.GetCommentByPostId(postId);
            foreach (var comment in postComments)
            {
                _commentService.Delete(comment.Id);
            }
        }

        private void DeletePostLikes(int postId)
        {
            var postComments = _likeService.GetLikeByPostId(postId);
            foreach (var like in postComments)
            {
                _likeService.Delete(like.Id);
            }
        }
    }
}
