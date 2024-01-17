using Microsoft.UI.Xaml.Controls;

using MvvmLab.ViewModels;

namespace MvvmLab.Views;

public sealed partial class RecipeDetailPage : Page
{
    public RecipeDetailViewModel ViewModel { get; }

    public RecipeDetailPage()
    {
        DataContext = ViewModel = App.GetService<RecipeDetailViewModel>();
        InitializeComponent();
    }
}
