using System.Net.Http.Json;

using MvvmLab.Core.Models;

namespace MvvmLab.Core.Services;

public class RecipeService : IRecipeService
{
    private readonly string _baseUrl = "https://bmecookbook.azurewebsites.net/api";

    public async Task<List<RecipeGroup>> GetRecipeGroupsAsync()
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<List<RecipeGroup>>($"{_baseUrl}/Recipes/Groups");
    }
}