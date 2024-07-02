using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

public class OptionsMenuViewModel : ObservableObject
{
    public ICommand DeletePostCommand { get; }
    public ICommand UpdatePostCommand { get; }
    public ICommand AdoptAnimalCommand { get; }

    public OptionsMenuViewModel()
    {
        DeletePostCommand = new RelayCommand(OnDeletePost);
        UpdatePostCommand = new RelayCommand(OnUpdatePost);
        AdoptAnimalCommand = new RelayCommand(OnAdoptAnimal);
    }

    private void OnDeletePost()
    {
        // Implement delete post functionality
    }

    private void OnUpdatePost()
    {
        // Implement update post functionality
    }

    private void OnAdoptAnimal()
    {
        // Implement adopt animal functionality
    }
}
