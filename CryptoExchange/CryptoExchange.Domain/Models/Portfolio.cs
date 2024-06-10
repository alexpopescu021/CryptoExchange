namespace CryptoExchange.Domain.Models
{
    public class Portfolio : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Value { get; set; }
        public User User { get; set; }
    }
}
