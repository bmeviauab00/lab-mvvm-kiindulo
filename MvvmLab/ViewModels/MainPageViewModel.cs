﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MvvmLab.Contracts.Services;
using MvvmLab.Contracts.ViewModels;
using MvvmLab.Core.Models;
using MvvmLab.Core.Services;
using MvvmLab.Services;

namespace MvvmLab.ViewModels;

public partial class MainPageViewModel : ObservableObject, INavigationAware
{
    private readonly IRecipeService _recipeService;
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private RecipeGroup[] _recipeGroups = Array.Empty<RecipeGroup>();

    public MainPageViewModel(IRecipeService recipeService, INavigationService navigationService)
    {
        _recipeService = recipeService;
        _navigationService = navigationService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        RecipeGroups = await _recipeService.GetRecipeGroupsAsync();
    }

    public void OnNavigatedFrom()
    {
    }

    [RelayCommand]
    private void RecipeSelected(RecipeHeader recipe)
    {
        _navigationService.NavigateTo(Pages.Detail, recipe.Id);
    }
}