using Frontend.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class UpdateAnimalSpecieView : Window
    {
        public AnimalSpecieViewModel AnimalSpecie { get; set; }

        public UpdateAnimalSpecieView(AnimalSpecieViewModel animalSpecie)
        {
            InitializeComponent();

            AnimalSpecie = animalSpecie;
            DataContext = this;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            AnimalSpecie.UpdateAnimalSpecie();
            Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
