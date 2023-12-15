using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class ProductDTO
    {
        [JsonPropertyName("productId")]
        public Guid ProductId { get; init; }

        [JsonPropertyName("productTitle")]
        public string? ProductTitle { get; init; }
        [JsonPropertyName("productCategoryId")]
        public Guid ProductCategoryId { get; init; }

        [JsonPropertyName("productDescription")]
        public string? ProductDescription { get; init; }

        [JsonPropertyName("productImage")]
        public string? ProductImage { get; init; }

        [JsonPropertyName("productDisplay")]
        public bool? ProductDisplay { get; init; }

        [JsonPropertyName("productPrice")]
        public int ProductPrice { get; init; }
    }
}
