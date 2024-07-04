using Backend.Models.UserModels;
using Backend.Services.AnimalServices;
using Backend.Services.PostServices;
using Frontend.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class CreatePostView : Window
    {
        public CreatePostView(User currentUser, PostService postService, AnimalService animalService, SpecieService specieService)
        {
            InitializeComponent();
            DataContext = new CreatePostViewModel(currentUser, postService, animalService, specieService);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
