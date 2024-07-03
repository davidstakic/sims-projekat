using Backend.Models.Enums;
using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;
using Backend.Services.VetOfficeServices;
using Frontend.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Frontend.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private readonly ProfileService _profileService;
        private readonly MemberService _memberService;
        private readonly VolunteerService _volunteerService;
        private SpecieService _specieService;
        private AnimalService _animalService;
        private PostService _postService;
        private LikeService _likeService;
        private CommentService _commentService;
        private TreatmentService _treatmentService;
        private FeedbackService _feedbackService;
        private AdoptionService _adoptionService;
        private DonationService _donationService;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            _profileService = new ProfileService();
            _memberService = new MemberService();
            _volunteerService = new VolunteerService();
            _specieService = new SpecieService();
            _animalService = new AnimalService() ;
            _postService = new PostService();
            _likeService = new LikeService();
            _commentService = new CommentService();
            _treatmentService = new TreatmentService();
            _feedbackService = new FeedbackService();
            _adoptionService = new AdoptionService();
            _donationService = new DonationService();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Login()
        {
            Profile loginProfile = _profileService.GetByUsernameAndPassword(Username, Password);
            if (loginProfile == null)
            {
                MessageBox.Show("Username or password incorrect!");
                return;
            }

            foreach (Member member in _memberService.GetAll())
            {
                Profile memberProfile = _profileService.GetById(member.ProfileId);
                if (loginProfile.Username == memberProfile.Username && loginProfile.Password == memberProfile.Password)
                {
                    if (member.Status == Status.Accepted && !member.IsBlacklisted)
                    {
                        new MemberMainPageView(member).Show();
                        Application.Current.MainWindow.Close();
                        return;
                    }
                    new PostsView(member).Show();
                    Application.Current.MainWindow.Close();
                }
            }

            foreach (Volunteer volunteer in _volunteerService.GetAll())
            {
                Profile volunteerProfile = _profileService.GetById(volunteer.ProfileId);
                if (loginProfile.Username == volunteerProfile.Username && loginProfile.Password == volunteerProfile.Password)
                {
                    if (volunteer.IsAdmin)
                    {
                        new AdministratorMainPageView(_specieService, _animalService, _postService, _likeService, _commentService, _treatmentService, _feedbackService, _adoptionService, _donationService).Show();
                        Application.Current.MainWindow.Close();
                        return;
                    }
                    new VolunteerMainPageView().Show();
                    Application.Current.MainWindow.Close();
                }
            }
        }
    }
}
