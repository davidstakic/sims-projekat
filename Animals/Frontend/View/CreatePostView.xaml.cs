using Backend.Models.UserModels;
using Frontend.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class CreatePostView : Window
    {
        private Member _currentMember { get; set; }

        public CreatePostView(Member currentMember)
        {
            InitializeComponent();
            _currentMember = currentMember;
            DataContext = new CreatePostViewModel(currentMember);
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
