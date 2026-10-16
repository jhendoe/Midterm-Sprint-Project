using MidtermSprint.Models;

namespace MidtermSprint.Services;

public class UserStore
{
    private readonly List<User> _users = new()
    {
        new() { Id = 1, Username = "DemoChef", Email = "demo@foodiehub.com", Password = "password123", Bio = "Home cook. Weekend baker. Adobo evangelist.", Avatar = "👩‍🍳" },
        new() { Id = 2, Username = "ChefMaria", Email = "maria@foodiehub.com", Password = "password123", Bio = "Sharing family recipes.", Avatar = "🧑‍🍳" }
    };

    public User? Validate(string email, string password) =>
        _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Password == password);

    public User? Register(string username, string email, string password, string bio = "", string avatar = "🧑‍🍳")
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            return null;

        if (_users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            return null;

        var user = new User
        {
            Id = (_users.Count == 0 ? 0 : _users.Max(u => u.Id)) + 1,
            Username = username.Trim(),
            Email = email.Trim(),
            Password = password,
            Bio = bio.Trim(),
            Avatar = avatar
        };

        _users.Add(user);
        return user;
    }
}
