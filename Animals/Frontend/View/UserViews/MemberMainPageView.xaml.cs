using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;
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

        public MemberMainPageView(Member currentMember, PostService postService,
            LikeService likeService, CommentService commentService, AnimalService animalService,
            SpecieService specieService, AdoptionService adoptionService, DonationService donationService, 
            ProfileService profileService, MemberService memberService)
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
            new PostsView(_currentMember, _postService, _likeService, _commentService, _animalService, _specieService, _adoptionService, _donationService).Show();
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
            _profileService.Delete(_currentMember.ProfileId);
            _memberService.Delete(_currentMember.Id);
            new MainWindow().Show();
            Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
