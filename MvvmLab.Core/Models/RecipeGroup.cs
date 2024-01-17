namespace MvvmLab.Core.Models;

public class RecipeGroup
{
    public string Id { get; set; }
    public string Title { get; set; }
    public List<RecipeHeader> Recipes { get; set; }
}
