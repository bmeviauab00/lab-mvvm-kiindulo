using Microsoft.UI.Xaml.Controls;

using MvvmLab.ViewModels;

namespace MvvmLab.Views;

public sealed partial class RecipeDetailPage : Page
{
    public RecipeDetailPageViewModel ViewModel => (RecipeDetailPageViewModel)DataContext;

    public RecipeDetailPage()
    {
        InitializeComponent();
    }
}
