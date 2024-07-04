using Backend.Models.Enums;
using Backend.Models.PostModels;
using Backend.Services.AnimalServices;
using Backend.Services.PostServices;
using CommunityToolkit.Mvvm.Input;
using Frontend.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Frontend.ViewModel.ModelViewModels.PostViewModels
{
    public class PostRequestsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Post>? _pendingPosts;

        public ObservableCollection<Post>? PendingPosts
        {
            get { return _pendingPosts; }
            set
            {
                _pendingPosts = value;
                OnPropertyChanged(nameof(PendingPosts));
            }
        }

        public ICommand AcceptPostCommand { get; private set; }
        public ICommand RejectPostCommand { get; private set; }

        public PostRequestsViewModel()
        {
            AcceptPostCommand = new RelayCommand<Post>(AcceptPost);
            RejectPostCommand = new RelayCommand<Post>(RejectPost);

            LoadPendingPosts();
        }

        private void LoadPendingPosts()
        {
            var postService = new PostService();
            var allPosts = postService.GetAll();
            var pendingPosts = new List<Post>();

            foreach (var post in allPosts)
            {
                if (post.Status == Status.Waiting)
                {
                    pendingPosts.Add(post);
                }
            }

            PendingPosts = new ObservableCollection<Post>(pendingPosts);
        }

        private void AcceptPost(Post? post)
        {
            if (post != null)
            {
                post.Status = Status.Accepted;
                new PostService().Update(post);
                new PrintMessageView("Post request has been accepted").Show();
                LoadPendingPosts();
            }
        }

        private void RejectPost(Post? post)
        {
            if (post != null)
            {
                new AnimalService().Delete(post.AnimalId);
                new PostService().Delete(post.Id);
                new PrintMessageView("Post request has been rejeted").Show();
                LoadPendingPosts();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
