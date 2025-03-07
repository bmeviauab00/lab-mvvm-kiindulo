using Lab.Mvvm.ViewModels;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Lab.Mvvm;

public sealed partial class BooksPage : Page
{
    public BooksPageViewModel ViewModel { get; } = new BooksPageViewModel();

    public BooksPage()
    {
        InitializeComponent();
    }
}
