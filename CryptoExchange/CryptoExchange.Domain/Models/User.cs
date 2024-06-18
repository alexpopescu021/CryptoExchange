namespace CryptoExchange.Domain.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
        public string Email { get; set; } = string.Empty;
        public string TelephoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}
