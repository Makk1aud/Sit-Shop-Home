using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class ProductForManipulationDTO
    {
        [Required(ErrorMessage ="ProductTitle field is required")]
        [MaxLength(100, ErrorMessage ="Max length for ProductTitle is 100 chars")]
        [JsonPropertyName("productTitle")]
        public string? ProductTitle { get; init; }

        [Required(ErrorMessage = "ProductCategoryId field is required")]
        [JsonPropertyName("productCategoryId")]
        public Guid? ProductCategoryId { get; init; }

        [Required(ErrorMessage = "ProductDescription field is required")]
        [MaxLength(300, ErrorMessage = "Max length for ProductDescription is 300 chars")]
        [JsonPropertyName("productDescription")]
        public string? ProductDescription { get; init; }

        [Required(ErrorMessage = "ProductImage field is required")]
        [MaxLength(100, ErrorMessage = "Max length for ProductImage is 100 chars")]
        [JsonPropertyName("productImage")]
        public string? ProductImage { get; init; }

        [Required(ErrorMessage = "ProductDisplay field is required")]
        [JsonPropertyName("productDisplay")]
        public bool? ProductDisplay { get; init; }

        [Range(0, int.MaxValue,ErrorMessage ="Price Cant be negative number")]
        [JsonPropertyName("productPrice")]
        public int ProductPrice { get; init; }
    }
}
