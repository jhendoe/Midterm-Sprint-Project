using MidtermSprint.Models;

namespace MidtermSprint.Services;

public class AuthState
{
    private readonly UserStore _users;

    public AuthState(UserStore users)
    {
        _users = users;
    }

    public User? CurrentUser { get; private set; }
    public bool IsLoggedIn => CurrentUser is not null;

    public bool Login(string email, string password)
    {
        CurrentUser = _users.Validate(email, password);
        return IsLoggedIn;
    }

    public bool Register(string username, string email, string password, string bio = "", string avatar = "🧑‍🍳")
    {
        CurrentUser = _users.Register(username, email, password, bio, avatar);
        return IsLoggedIn;
    }

    public void Logout() => CurrentUser = null;
}
