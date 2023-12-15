using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class CustomerDTO()
    {
        [JsonPropertyName("customerId")]        
        public Guid CustomerId { get; init; }
        [JsonPropertyName("customerFullName")] 
        public string? CustomerFullName { get; init; }
        [JsonPropertyName("customerPhone")]
        public string? CustomerPhone { get; init; }
        [JsonPropertyName("customerEmail")]
        public string? CustomerEmail { get; init; }
        [JsonPropertyName("genderId")]
        public Guid GenderId { get; init; }
        [JsonPropertyName("customerPassword")]
        public string? CustomerPassword { get; init; }
        [JsonPropertyName("customerBirth")]
        public DateOnly CustomerBirth { get; init; }
    }
}
