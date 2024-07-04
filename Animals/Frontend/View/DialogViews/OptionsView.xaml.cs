using Backend.Services.AnimalServices;
using Backend.Services.AssociationServices;
using Backend.Services.PostServices;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View;
public partial class OptionsView : Window
{
    public OptionsView(int userId, int postId, PostService postService, LikeService likeService, CommentService commentService, AnimalService animalService, SpecieService specieService, AdoptionService adoptionService, DonationService donationService, PostDetailView postDetailedView)
    {
        InitializeComponent();
        DataContext = new OptionsViewModel(userId, postId, postService, likeService, commentService, animalService, specieService, adoptionService, donationService, postDetailedView);
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
