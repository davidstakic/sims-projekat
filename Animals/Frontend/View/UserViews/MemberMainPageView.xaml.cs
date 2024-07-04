using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;
using Frontend.ViewModel.ModelViewModels.UserViewModels;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class MemberMainPageView : Window
    {
        private Member _currentMember;
        private PostService _postService;
        private LikeService _likeService;
        private CommentService _commentService;
        private AnimalService _animalService;
        private SpecieService _specieService;
        private AdoptionService _adoptionService;
        private DonationService _donationService;
        private ProfileService _profileService;
        private MemberService _memberService;
        private VolunteerService _volunteerService;

        public MemberMainPageView(Member currentMember, PostService postService,
            LikeService likeService, CommentService commentService, AnimalService animalService,
            SpecieService specieService, AdoptionService adoptionService, DonationService donationService, 
            ProfileService profileService, MemberService memberService, VolunteerService volunteerService)
        {
            InitializeComponent();
            _currentMember = currentMember;
            _postService = postService;
            _likeService = likeService;
            _commentService = commentService;
            _animalService = animalService;
            _specieService = specieService;
            _adoptionService = adoptionService;
            _donationService = donationService;
            _profileService = profileService;
            _memberService = memberService;
            _volunteerService = volunteerService;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void Posts_Click(object sender, RoutedEventArgs e)
        {
            new PostsView(_currentMember, _postService, _likeService, _commentService, _animalService, _specieService, _adoptionService, _donationService, _memberService, _volunteerService).Show();
        }

        private void Donate_Click(object sender, RoutedEventArgs e)
        {
            new DonationView(_currentMember).Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            new MemberUpdateView(_currentMember).Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var destructiveActionView = new ActionView("Are you sure you want to delete?");

            destructiveActionView.OnYesAction = () =>
            {
                _memberService.Delete(_currentMember.Id);
                _profileService.Delete(_currentMember.ProfileId);
                DeleteUserPosts(_currentMember.Id);
                DeleteUserComments(_currentMember.Id);
                DeleteUserLikes(_currentMember.Id);
                DeleteAdoption(_currentMember.Id);
                new PrintMessageView("Successfuly deleted member.").Show();
                new MainWindow().Show();
                Close();
            };

            destructiveActionView.ShowDialog();
        }

        private void DeleteAdoption(int userId)
        {
            var userAdoptions = _adoptionService.GetAdoptionByUserId(userId);
            foreach (var adoption in userAdoptions)
            {
                _adoptionService.Delete(adoption.Id);
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
