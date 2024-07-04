using System.Windows;

namespace Frontend.View
{
    public partial class CreateCommentView : Window
    {
        public CreateCommentView(CreateCommentViewModel newCommentViewModel)
        {
            InitializeComponent();
            DataContext = newCommentViewModel;
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
