﻿using System.Net.Http.Json;

using MvvmLab.Core.Models;

namespace MvvmLab.Core.Services;

public class RecipeService : IRecipeService
{
    private readonly string _baseUrl = "https://bmecookbook2.azurewebsites.net/api";

    public async Task<RecipeGroup[]> GetRecipeGroupsAsync()
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<RecipeGroup[]>($"{_baseUrl}/Recipes/Groups");
    }

    public async Task<Recipe> GetRecipeAsync(int id)
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<Recipe>($"{_baseUrl}/Recipes/{id}");
    }

    public async Task SendCommentAsync(int id, Comment comment)
    {
        using var client = new HttpClient();
        var response = await client.PostAsJsonAsync($"{_baseUrl}/Recipes/{id}/Comments", comment);
        response.EnsureSuccessStatusCode();
    }
}