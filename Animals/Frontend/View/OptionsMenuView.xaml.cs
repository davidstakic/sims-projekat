using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class OptionsMenuView : Window
    {
        public OptionsMenuView()
        {
            InitializeComponent();
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
            this.Close();
        }
    }
}
