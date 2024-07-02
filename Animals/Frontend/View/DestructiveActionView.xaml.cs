using System.Windows;

namespace Frontend.View
{
    public partial class DestructiveActionView : Window
    {
        public Action OnYesAction { get; set; }

        public DestructiveActionView()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            OnYesAction?.Invoke();
            Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
