using System.Windows;

namespace Frontend.View
{
    public partial class CreateAnimalSpecieView : Window
    {
        public CreateAnimalSpecieView()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
