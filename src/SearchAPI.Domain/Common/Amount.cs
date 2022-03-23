using System.Collections.Generic;

namespace SearchAPI.Domain.Common
{
    public record Amount
    {
        public decimal Value { get; set; }
        
        public string Currency { get; set; }

        public Amount()
        {
        }
        
        public Amount(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }
    }
}