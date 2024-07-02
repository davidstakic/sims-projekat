using Backend.Models.PostModels;
using Backend.Models.AnimalModels;
using Backend.Models.UserModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;

public class PostsViewModel : INotifyPropertyChanged
{
    private ObservableCollection<PostDetailViewModel> posts;

    public ObservableCollection<PostDetailViewModel> Posts
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
        var memberData = LoadDataFromFile<Member>("../../../../Backend/Data/Members.json");
        var animalsData = LoadDataFromFile<Animal>("../../../../Backend/Data/Animals.json");
        var speciesData = LoadDataFromFile<AnimalSpecie>("../../../../Backend/Data/Species.json");

        var postsWithDetails = from post in postsData
                               join like in likesData on post.Id equals like.PostId into postLikes
                               join comment in commentsData on post.Id equals comment.PostId into postComments
                               join member in memberData on post.UserId equals member.Id
                               join animal in animalsData on post.AnimalId equals animal.Id
                               join specie in speciesData on animal.AnimalSpecieId equals specie.Id
                               select new PostDetailViewModel(post, member, animal, specie.Name, postLikes.Count(), postComments.Count());

        Posts = new ObservableCollection<PostDetailViewModel>(postsWithDetails);
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
