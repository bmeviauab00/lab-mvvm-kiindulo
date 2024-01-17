using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SendCommentCommand))]
    private string _newCommentName = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SendCommentCommand))]
    private string _newCommentText = string.Empty;

    public async void OnNavigatedTo(object parameter)
    {
        Recipe = await _recipeService.GetRecipeAsync((int)parameter);
    }

    public void OnNavigatedFrom()
    {
    }

    private bool CanExecuteSendComment => !string.IsNullOrEmpty(NewCommentName) && !string.IsNullOrEmpty(NewCommentText);

    [RelayCommand(CanExecute = nameof(CanExecuteSendComment))]
    private async Task SendComment()
    {
        var newComment = new NewComment
        {
            Email = NewCommentName,
            Text = NewCommentText
        };

        await _recipeService.SendCommentAsync(Recipe!.Id, newComment);

        NewCommentName = string.Empty;
        NewCommentText = string.Empty;

        Recipe = await _recipeService.GetRecipeAsync(Recipe.Id);
    }
}
