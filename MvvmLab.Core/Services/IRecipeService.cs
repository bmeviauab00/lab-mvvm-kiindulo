using MvvmLab.Core.Models;

namespace MvvmLab.Core.Services;

public interface IRecipeService
{
    public Task<List<RecipeGroup>> GetRecipeGroupsAsync();
}
