using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class ActionView : Window
    {
        public Action OnYesAction { get; set; }

        public ActionView(string action)
        {
            InitializeComponent();
            Message.Text = action;
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
