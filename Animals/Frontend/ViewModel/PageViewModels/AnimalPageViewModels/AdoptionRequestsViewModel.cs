using Backend.Models.AnimalModels;
using Backend.Models.Enums;
using Backend.Models.PostModels;
using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.PostServices;
using CommunityToolkit.Mvvm.Input;
using Frontend.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Frontend.ViewModel.ModelViewModels.AnimalViewModels
{
    public class AdoptionRequestsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Adoption>? _pendingAdoptions;
        private PostService _postService;
        private CommentService _commentService;
        private LikeService _likeService;

        public ObservableCollection<Adoption>? PendingAdoptions
        {
            get { return _pendingAdoptions; }
            set
            {
                _pendingAdoptions = value;
                OnPropertyChanged(nameof(PendingAdoptions));
            }
        }

        public ICommand AcceptAdoptionCommand { get; private set; }
        public ICommand RejectAdoptionCommand { get; private set; }

        public AdoptionRequestsViewModel(PostService postService, CommentService commentService, LikeService likeService)
        {
            _postService = postService;
            _commentService = commentService;
            _likeService = likeService;
            AcceptAdoptionCommand = new RelayCommand<Adoption>(AcceptAdoption);
            RejectAdoptionCommand = new RelayCommand<Adoption>(RejectAdoption);

            LoadPendingAdoptions();
        }

        private void LoadPendingAdoptions()
        {
            var adoptionService = new AdoptionService();
            var allAdoptions = adoptionService.GetAll();
            var pendingAdoptions = new List<Adoption>();

            foreach (var adoption in allAdoptions)
            {
                if (adoption.Status == Status.Waiting)
                {
                    pendingAdoptions.Add(adoption);
                }
            }

            PendingAdoptions = new ObservableCollection<Adoption>(pendingAdoptions);
        }

        private void AcceptAdoption(Adoption? adoption)
        {
            if (adoption != null)
            {
                _deleteAdoptionComment(adoption);
                adoption.Status = Status.Accepted;
                new AdoptionService().Update(adoption);
                new PrintMessageView("Adoption has been accepted").Show();
                LoadPendingAdoptions();
            }
        }

        private void _deleteAdoptionComment(Adoption adoption)
        {
            int animalId = adoption.AnimalId;
            Post post = _postService.GetPostByAnimalId(animalId);
            List<Comment> comments = _commentService.GetCommentByPostId(post.Id);
            List<Like> likes = _likeService.GetLikeByPostId(post.Id);
            foreach (Comment comment in comments)
            {
                _commentService.Delete(comment.Id);
            }
            foreach (Like like in likes)
            {
                _likeService.Delete(like.Id);
            }
            _postService.Delete(post.Id);
        }

        private void RejectAdoption(Adoption? adoption)
        {
            if (adoption != null)
            {
                new AdoptionService().Delete(adoption.Id);
                new PrintMessageView("Adoption has been rejected").Show();
                LoadPendingAdoptions();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
