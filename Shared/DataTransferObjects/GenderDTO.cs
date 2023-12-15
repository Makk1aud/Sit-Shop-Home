using System.Text.Json.Serialization;

namespace Shared.DataTransferObjects;

public record class GenderDTO
{
    [JsonPropertyName("id")]
    public Guid GenderId { get; set; }
    [JsonPropertyName("title")]
    public string? GenderTitle { get; set; }
} 
