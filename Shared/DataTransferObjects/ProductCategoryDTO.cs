using System.Text.Json.Serialization;

namespace Shared.DataTransferObjects;

public record class ProductCategoryDTO
{
    [JsonPropertyName("id")]
    public Guid ProductCategoryId { get; set; }
    [JsonPropertyName("title")]
    public string? ProductCategoriesTitle { get; set; }
}