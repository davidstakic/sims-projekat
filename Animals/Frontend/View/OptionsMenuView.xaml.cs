using System.Windows;

namespace Frontend.View
{
    public partial class OptionsMenuView : Window
    {
        public OptionsMenuView()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
