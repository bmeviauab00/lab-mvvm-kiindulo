using Microsoft.UI.Xaml.Controls;

using MvvmLab.ViewModels;

namespace MvvmLab.Views;

public sealed partial class RecipeDetailPage : Page
{
    public RecipeDetailViewModel ViewModel => (RecipeDetailViewModel)DataContext;

    public RecipeDetailPage()
    {
        InitializeComponent();
    }
}
