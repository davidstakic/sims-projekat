using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using Backend.Services.VetOfficeServices;
using Frontend.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class AnimalSpeciesView : Window
    {
        private SpecieService _specieService;
        private AnimalService _animalService;
        private PostService _postService;
        private LikeService _likeService;
        private CommentService _commentService;
        private TreatmentService _treatmentService;
        private FeedbackService _feedbackService;
        private AdoptionService _adoptionService;
        private DonationService _donationService;

        public AnimalSpeciesView(SpecieService specieService, AnimalService animalService, PostService postService, LikeService likeService, CommentService commentService, TreatmentService treatmentService, FeedbackService feedbackService, AdoptionService adoptionService, DonationService donationService)
        {
            InitializeComponent();

            _specieService = specieService;
            _animalService = animalService;
            _postService = postService;
            _likeService = likeService;
            _commentService = commentService;
            _treatmentService = treatmentService;
            _feedbackService = feedbackService;
            _adoptionService = adoptionService;
            _donationService = donationService;
             
            DataContext = new AnimalSpeciesListViewModel(_specieService);

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
            new CreateAnimalSpecieView(_specieService).Show();
        }

        private void EditImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is AnimalSpecieViewModel specieViewModel)
            {
                var updateWindow = new UpdateAnimalSpecieView(specieViewModel);
                updateWindow.Show();
            }
        }

        private void DeleteImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is AnimalSpecieViewModel specieViewModel)
            {
                var destructiveActionView = new DestructiveActionView();

                destructiveActionView.OnYesAction = () =>
                {
                    DeleteSpecie(specieViewModel.Id);
                };

                destructiveActionView.ShowDialog();
            }
        }

        private void DeleteSpecie(int specieId)
        {
            var animalsToDelete = _animalService.GetAnimalByAnimalSpecieId(specieId);

            foreach (var animal in animalsToDelete)
            {
                DeleteRelatedPosts(animal.Id);
                DeleteRelatedTreatments(animal.Id);
                DeleteRelatedFeedbacks(animal.Id);
                DeleteRelatedAdoptions(animal.Id);
                DeleteRelatedDonations(animal.Id);
                _animalService.Delete(animal.Id);
            }

            _specieService.Delete(specieId);
        }

        private void DeleteRelatedPosts(int animalId)
        {
            var postsTodelete = _postService.GetPostByAnimalId(animalId);

            foreach (var post in postsTodelete)
            {
                DeleteComments(post.Id);
                DeleteLikes(post.Id);
                _postService.Delete(post.Id);
            }
        }

        private void DeleteLikes(int postId)
        {
            var likesToDelete = _likeService.GetLikeByPostId(postId);

            foreach (var like in likesToDelete)
            {
                _likeService.Delete(like.Id);
            }
        }

        private void DeleteComments(int postId)
        {
            var commentsToDelete = _commentService.GetCommentByPostId(postId).ToList();

            foreach (var comment in commentsToDelete)
            {
                _commentService.Delete(comment.Id);
            }
        }

        private void DeleteRelatedTreatments(int animalId)
        {
            var treatmentsToDelete = _treatmentService.GetTreatmentByAnimalId(animalId);

            foreach (var treatment in treatmentsToDelete)
            {
                _treatmentService.Delete(treatment.Id);
            }
        }

        private void DeleteRelatedFeedbacks(int animalId)
        {
            var feedbacksToDelete = _feedbackService.GetAnimalFeedbackByAnimalId(animalId).ToList();

            foreach (var feedback in feedbacksToDelete)
            {
                _feedbackService.Delete(feedback.Id);
            }
        }

        private void DeleteRelatedAdoptions(int animalId)
        {
            var adoptionsToDelete = _adoptionService.GetAdoptionByAnimalId(animalId);

            foreach (var adoption in adoptionsToDelete)
            {
                _adoptionService.Delete(adoption.Id);
            }
        }

        private void DeleteRelatedDonations(int animalId)
        {
            var donationsToDelete = _donationService.GetDonationByAnimalId(animalId);

            foreach (var donation in donationsToDelete)
            {
                donation.AnimalId = -1;
                _donationService.Update(donation);
            }
        }
    }
}
