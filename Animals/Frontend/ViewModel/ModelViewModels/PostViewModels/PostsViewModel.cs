using Backend.Models.PostModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;

public class PostsViewModel : INotifyPropertyChanged
{
    private ObservableCollection<PostViewModel> posts;

    public ObservableCollection<PostViewModel> Posts
    {
        get { return posts; }
        set
        {
            posts = value;
            OnPropertyChanged("Posts");
        }
    }

    public PostsViewModel()
    {
        // Load data from JSON files
        var postsData = LoadDataFromFile<Post>("../../../../Backend/Data/Posts.json");
        var likesData = LoadDataFromFile<Like>("../../../../Backend/Data/Likes.json");
        var commentsData = LoadDataFromFile<Comment>("../../../../Backend/Data/Comments.json");
        var memberData = LoadDataFromFile<Comment>("../../../../Backend/Data/Members.json");

        var postsWithDetails = from post in postsData
                               join like in likesData on post.Id equals like.PostId into postLikes
                               join comment in commentsData on post.Id equals comment.PostId into postComments
                               select new PostViewModel(post, postLikes.Count(), postComments.Count());

        Posts = new ObservableCollection<PostViewModel>(postsWithDetails);
    }

    private ObservableCollection<T> LoadDataFromFile<T>(string fileName)
    {
        var jsonData = File.ReadAllText(fileName);
        return JsonConvert.DeserializeObject<ObservableCollection<T>>(jsonData)!;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
