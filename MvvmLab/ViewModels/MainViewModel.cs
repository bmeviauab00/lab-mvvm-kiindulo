using CommunityToolkit.Mvvm.ComponentModel;

using MvvmLab.Contracts.ViewModels;
using MvvmLab.Core.Models;
using MvvmLab.Core.Services;

namespace MvvmLab.ViewModels;

public partial class MainViewModel : ObservableRecipient, INavigationAware
{
    private readonly IRecipeService _recipeService;

    [ObservableProperty]
    private List<RecipeGroup>? _recipeGroups = new();

    public MainViewModel(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        RecipeGroups = await _recipeService.GetRecipeGroupsAsync();
    }

    public void OnNavigatedFrom()
    {
    }
}
