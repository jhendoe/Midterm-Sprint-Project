namespace MidtermSprint.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string Bio { get; set; } = "";
    public string Avatar { get; set; } = "🧑‍🍳";
    public HashSet<int> FavoriteRecipeIds { get; set; } = new();
}
