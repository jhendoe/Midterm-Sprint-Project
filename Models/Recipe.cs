namespace MidtermSprint.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Cuisine { get; set; } = "";
    public string Emoji { get; set; } = "🍽️";
    public int CookTimeMinutes { get; set; }
    public List<string> Ingredients { get; set; } = new();
    public List<string> Steps { get; set; } = new();
    public int AuthorId { get; set; }
    public string AuthorName { get; set; } = "";
    public bool IsFeatured { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public List<Review> Reviews { get; set; } = new();

    public double AverageRating => Reviews.Count == 0 ? 0 : Reviews.Average(r => r.Rating);
}
