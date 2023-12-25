using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class PurchaseDTO
    {
        [JsonPropertyName("purchaseId")]
        public Guid PurchaseId { get; init; }

        [JsonPropertyName("customerId")]
        public Guid CustomerId { get; init; }

        [JsonPropertyName("productId")]
        public Guid ProductId { get; init; }

        [JsonPropertyName("purchaseDate")]
        public DateTime PurchaseDate { get; init; }

        [JsonPropertyName("purchaseCard")]
        public string? PurchaseCard { get; init; }
    }
}
