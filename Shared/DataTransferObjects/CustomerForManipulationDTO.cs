using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class CustomerForManipulationDTO
    {
        [Required(ErrorMessage ="Name filed is required")]
        [MaxLength(30, ErrorMessage ="For field Name max length is 30 chars")]
        public string? CustomerName { get; init; }

        [MaxLength(30, ErrorMessage = "For field Name max length is 30 chars")]
        public string? CustomerSurname { get; init; }

        [MaxLength(13, ErrorMessage = "For field Name max length is 13 chars")]
        public string? CustomerPhone { get; init; }

        [Required(ErrorMessage ="Email field is required")]
        [EmailAddress(ErrorMessage ="That address cant be real, Email field")]
        public string? CustomerEmail { get; init; }

        [Required(ErrorMessage = "Gender field is required")]
        public Guid? GenderId { get; init; }

        [Required(ErrorMessage = "Password filed is required")]
        [MaxLength(30, ErrorMessage = "For field Password max length is 20 chars")]
        public string? CustomerPassword { get; init; }

        //[FromQuery(Name ="date")]
        //[Required(ErrorMessage = "Birth filed is required")]
        //public DateTime? CustomerBirth { get; init; }
    }
}
