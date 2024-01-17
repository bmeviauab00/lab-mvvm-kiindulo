using CommunityToolkit.Mvvm.ComponentModel;

using MvvmLab.Contracts.ViewModels;
using MvvmLab.Core.Models;
using MvvmLab.Core.Services;

namespace MvvmLab.ViewModels;

public partial class RecipeDetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly IRecipeService _recipeService;

    public RecipeDetailViewModel(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [ObservableProperty]
    private Recipe? _recipe;

    public async void OnNavigatedTo(object parameter)
    {
        Recipe = await _recipeService.GetRecipeAsync((int)parameter);
    }

    public void OnNavigatedFrom()
    {
    }
}

