using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class CustomerForManipulationDTO
    {

        [JsonPropertyName("customerName")]
        [Required(ErrorMessage ="Name filed required")]
        [MaxLength(30, ErrorMessage ="For field Name max length is 30 chars")]
        public string? CustomerName { get; init; }

        [JsonPropertyName("customerSurname")]
        [MaxLength(30, ErrorMessage = "For field Name max length is 30 chars")]
        public string? CustomerSurname { get; init; }

        [JsonPropertyName("customerPhone")]
        [MaxLength(13, ErrorMessage = "For field Name max length is 13 chars")]
        public string? CustomerPhone { get; init; }

        [JsonPropertyName("customerEmail")]
        [Required(ErrorMessage ="Email field is required")]
        [EmailAddress(ErrorMessage ="That address cant be real, Email field")]
        public string? CustomerEmail { get; init; }

        [JsonPropertyName("genderId")]
        [Required(ErrorMessage = "Gender field is required")]
        public Guid? GenderId { get; init; }

        [JsonPropertyName("customerPassword")]
        [Required(ErrorMessage = "Password filed is required")]
        [MaxLength(20, ErrorMessage = "For field Password max length is 20 chars")]
        public string? CustomerPassword { get; init; }

        //[FromQuery(Name ="date")]
        //[Required(ErrorMessage = "Birth filed is required")]
        //public DateTime? CustomerBirth { get; init; }
    }
}
