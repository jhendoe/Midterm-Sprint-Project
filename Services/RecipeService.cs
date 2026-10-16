using MidtermSprint.Models;

namespace MidtermSprint.Services;

public class RecipeService
{
    public IReadOnlyList<Cuisine> Cuisines { get; } = new List<Cuisine>
    {
        new("Italian", "🍝"),
        new("Filipino", "🍲"),
        new("Mexican", "🌮"),
        new("Japanese", "🍣"),
        new("Dessert", "🍰"),
        new("Homemade Goods", "🍯")
    };

    private readonly List<Recipe> _recipes = new()
    {
        new() { Id = 1, Title = "Classic Carbonara", Cuisine = "Italian", Emoji = "🍝", CookTimeMinutes = 25, IsFeatured = true, Description = "Silky egg-and-cheese sauce, crispy guanciale, no cream.", AuthorId = 2, AuthorName = "ChefMaria", Ingredients = new() { "200g spaghetti", "100g guanciale", "2 eggs + 1 yolk", "50g pecorino", "Black pepper" }, Steps = new() { "Boil pasta.", "Crisp guanciale.", "Mix eggs and cheese.", "Toss off the heat." }, Reviews = new() { new() { RecipeId = 1, UserId = 1, UserName = "DemoChef", Rating = 5, Comment = "Perfect texture!" } } },
        new() { Id = 2, Title = "Chicken Adobo", Cuisine = "Filipino", Emoji = "🍲", CookTimeMinutes = 50, IsFeatured = true, Description = "Tangy, savory and garlicky. Better the next day.", AuthorId = 1, AuthorName = "DemoChef", Ingredients = new() { "1kg chicken", "1/2 cup soy sauce", "1/3 cup vinegar", "8 garlic cloves", "Bay leaves" }, Steps = new() { "Marinate chicken.", "Simmer 30 min.", "Reduce the sauce." } },
        new() { Id = 3, Title = "Street-Style Tacos", Cuisine = "Mexican", Emoji = "🌮", CookTimeMinutes = 30, IsFeatured = true, Description = "Charred tortillas, lime and a lot of cilantro.", AuthorId = 2, AuthorName = "ChefMaria", Ingredients = new() { "Corn tortillas", "Skirt steak", "Onion", "Cilantro", "Limes" }, Steps = new() { "Grill steak.", "Chop.", "Assemble with onion and cilantro." }, Reviews = new() { new() { RecipeId = 3, UserId = 1, UserName = "DemoChef", Rating = 4, Comment = "Great with extra lime." } } },
        new() { Id = 4, Title = "Salmon Nigiri", Cuisine = "Japanese", Emoji = "🍣", CookTimeMinutes = 40, Description = "Simple sushi rice topped with fresh salmon.", AuthorId = 2, AuthorName = "ChefMaria", Ingredients = new() { "Sushi rice", "Rice vinegar", "Fresh salmon", "Wasabi" }, Steps = new() { "Season rice.", "Shape.", "Top with salmon." } },
        new() { Id = 5, Title = "Ube Cheesecake", Cuisine = "Dessert", Emoji = "🍰", CookTimeMinutes = 90, IsFeatured = true, Description = "Purple, creamy and not too sweet.", AuthorId = 1, AuthorName = "DemoChef", Ingredients = new() { "Cream cheese", "Ube halaya", "Graham crackers", "Butter" }, Steps = new() { "Make crust.", "Blend filling.", "Bake and chill overnight." } },
        new() { Id = 6, Title = "Wildflower Honey Granola", Cuisine = "Homemade Goods", Emoji = "🍯", CookTimeMinutes = 45, Description = "Crunchy, nutty and great as a gift in a jar.", AuthorId = 2, AuthorName = "ChefMaria", Ingredients = new() { "Oats", "Almonds", "Honey", "Coconut oil", "Sea salt" }, Steps = new() { "Mix.", "Bake at 160°C for 30 min.", "Cool completely." } }
    };

    public event Action? Changed;

    public IEnumerable<Recipe> GetAll(string? cuisine = null) =>
        _recipes.Where(r => string.IsNullOrEmpty(cuisine) || r.Cuisine == cuisine)
            .OrderByDescending(r => r.IsFeatured)
            .ThenByDescending(r => r.CreatedAt);

    public IEnumerable<Recipe> GetByAuthor(int userId) => _recipes.Where(r => r.AuthorId == userId);
    public IEnumerable<Review> GetReviewsBy(int userId) => _recipes.SelectMany(r => r.Reviews).Where(r => r.UserId == userId);
    public IEnumerable<Recipe> GetFavorites(User user) => _recipes.Where(r => user.FavoriteRecipeIds.Contains(r.Id));
    public Recipe? Find(int id) => _recipes.FirstOrDefault(r => r.Id == id);

    public void Add(Recipe recipe, User author)
    {
        recipe.Id = _recipes.Max(r => r.Id) + 1;
        recipe.AuthorId = author.Id;
        recipe.AuthorName = author.Username;
        recipe.Emoji = Cuisines.FirstOrDefault(c => c.Name == recipe.Cuisine)?.Emoji ?? "🍽️";
        _recipes.Add(recipe);
        Changed?.Invoke();
    }

    public void AddReview(int recipeId, User user, int rating, string comment)
    {
        Find(recipeId)?.Reviews.Add(new Review
        {
            RecipeId = recipeId,
            UserId = user.Id,
            UserName = user.Username,
            Rating = rating,
            Comment = comment
        });
        Changed?.Invoke();
    }

    public void ToggleFavorite(User user, int recipeId)
    {
        if (!user.FavoriteRecipeIds.Remove(recipeId)) user.FavoriteRecipeIds.Add(recipeId);
        Changed?.Invoke();
    }
}
