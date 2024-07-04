using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Backend.Models.Enums;
using Backend.Models.PostModels;
using Backend.Services.AnimalServices;
using Backend.Services.PostServices;
using CommunityToolkit.Mvvm.Input;

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
            // Initialize commands
            AcceptPostCommand = new RelayCommand<Post>(AcceptPost);
            RejectPostCommand = new RelayCommand<Post>(RejectPost);

            // Load pending posts initially
            LoadPendingPosts();
        }

        private void LoadPendingPosts()
        {
            var postService = new PostService(); // Replace with your actual service initialization
            var allPosts = postService.GetAll(); // Replace with your actual method to get all posts
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
                LoadPendingPosts(); // Reload pending posts after accepting
            }
        }

        private void RejectPost(Post? post)
        {
            if (post != null)
            {
                new AnimalService().Delete(post.AnimalId);
                new PostService().Delete(post.Id);
                LoadPendingPosts(); // Reload pending posts after rejecting
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
