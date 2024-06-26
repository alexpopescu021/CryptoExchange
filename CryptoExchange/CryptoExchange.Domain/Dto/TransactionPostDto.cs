﻿namespace CryptoExchange.Domain.Dto
{
    public class TransactionPostDto
    {
        public string SourceCurrencyCode { get; set; } = string.Empty;
        public string TargetCurrencyCode { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
        // change from Price
        public decimal SourcePrice { get; set; }
        public decimal TargetPrice { get; set; }

    }
}
