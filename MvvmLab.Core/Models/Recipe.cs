namespace MvvmLab.Core.Models;

public class Recipe
{
    public int Id { get; set; }
    public string BackgroundImage { get; set; }
    public string Title { get; set; }
    public string[] ExtraImages { get; set; }
    public string[] Ingredients { get; set; }
    public string Directions { get; set; }
    public Comment[] Comments { get; set; }
}


