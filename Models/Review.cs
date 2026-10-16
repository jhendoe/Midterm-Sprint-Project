namespace MidtermSprint.Models;

public class Review
{
    public int RecipeId { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; } = "";
    public int Rating { get; set; } = 5;
    public string Comment { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
