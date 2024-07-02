using Frontend.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class CreatePostView : Window
    {
        private int _currentUser { get; set; }

        public CreatePostView(int currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            DataContext = new CreatePostViewModel(currentUser);
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
