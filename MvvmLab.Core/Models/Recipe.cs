namespace MvvmLab.Core.Models;

public class Recipe
{
    public List<string> ExtraImages { get; set; }
    public List<string> Ingredients { get; set; }
    public string Directions { get; set; }
    public string Video { get; set; }
    public List<Comment> Comments { get; set; }
    public List<StoresNearby> StoresNearby { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public string BackgroundImage { get; set; }
    public string TileImage { get; set; }
}

