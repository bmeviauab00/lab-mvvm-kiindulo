using Microsoft.UI.Xaml.Controls;

using MvvmLab.ViewModels;

namespace MvvmLab.Views;

public sealed partial class MainPage : Page
{
    public MainPageViewModel ViewModel => DataContext as MainPageViewModel;

    public MainPage()
    {
        InitializeComponent();
    }
}
