namespace Tourmine.Users.Infrastructure
{
    public abstract class Settings
    {
        public static string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=user-tourmine"
            ?? string.Empty;
    }
}
