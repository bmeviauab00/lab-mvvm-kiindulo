namespace MvvmLab.Core.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Directions { get; set; }
    public string BackgroundImage { get; set; }
    public List<string> Ingredients { get; set; }
    public List<string> ExtraImages { get; set; }
    public List<Comment> Comments { get; set; }
}

