using System.Windows;
using System.Windows.Input;
using Frontend.ViewModels;
using Backend.Services.AnimalServices;
using Backend.Services.PostServices;
using Backend.Services.UserServices;

namespace Frontend.View
{
    public partial class UpdatePostView : Window
    {
        public UpdatePostView(int postId, int userId, PostService postService, AnimalService animalService, SpecieService specieService)
        {
            InitializeComponent();
            DataContext = new UpdatePostViewModel(postId, userId, postService, animalService, specieService);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
