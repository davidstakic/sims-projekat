using Backend.Services.AnimalServices;
using Frontend.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Frontend.View
{
    public partial class CreateAnimalSpecieView : Window
    {
        public AnimalSpecieViewModel AnimalSpecie { get; set; }

        public CreateAnimalSpecieView(SpecieService specieService)
        {
            InitializeComponent();

            AnimalSpecie = new AnimalSpecieViewModel(specieService);
            DataContext = this;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            AnimalSpecie.CreateAnimalSpecie();
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
