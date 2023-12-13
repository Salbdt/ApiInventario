namespace Inventory.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public bool Active { get; set; }

        // Authentication
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}