namespace CryptoExchange.Domain.Models
{
    public class User : Entity
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string TelephoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}
