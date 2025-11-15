namespace TableUp.Domain.Entities
{
    public class User: BaseEntity
    {
        public User(string name, string username, string email, string passwordHash)
        {
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            Name = name;
        }

        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime? LastLoginAt { get; private set; }
    }
}