using MvvmLab.Core.Models;

namespace MvvmLab.Core.Services;

public interface IRecipeService
{
    public Task<RecipeGroup[]> GetRecipeGroupsAsync();
    public Task<Recipe> GetRecipeAsync(int id);
    public Task SendCommentAsync(int id, Comment comment);
}
