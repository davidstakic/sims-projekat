using System.Windows;

namespace Frontend.View
{
    public partial class PrintMessageView : Window
    {
        public PrintMessageView(string message)
        {
            InitializeComponent();

            Message.Text = message;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
