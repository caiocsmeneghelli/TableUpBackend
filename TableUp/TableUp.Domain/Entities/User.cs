using TableUp.Domain.Enums;

namespace TableUp.Domain.Entities
{
    public class User
    {
        public User(string name, string username, string email, string passwordHash)
        {
            Guid = Guid.NewGuid();
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            Name = name;

            Status = EStatus.Active;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid Guid { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime? LastLoginAt { get; private set; }

        public EStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }


        public void Deactivate()
        {
            Status = EStatus.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}