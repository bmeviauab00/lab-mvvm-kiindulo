using Microsoft.UI.Xaml.Controls;

using MvvmLab.ViewModels;

namespace MvvmLab.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
