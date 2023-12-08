using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class ProductForManipulationDTO
    {
        [Required(ErrorMessage ="ProductTitle field is required")]
        [MaxLength(100, ErrorMessage ="Max length for ProductTitle is 100 chars")]
        public string? ProductTitle { get; init; }

        [Required(ErrorMessage = "ProductCategoryId field is required")]
        public Guid? ProductCategoryId { get; init; }

        [Required(ErrorMessage = "ProductDescription field is required")]
        [MaxLength(300, ErrorMessage = "Max length for ProductDescription is 300 chars")]
        public string? ProductDescription { get; init; }

        [Required(ErrorMessage = "ProductImage field is required")]
        [MaxLength(100, ErrorMessage = "Max length for ProductImage is 100 chars")]
        public string? ProductImage { get; init; }

        [Required(ErrorMessage = "ProductDisplay field is required")]
        public bool? ProductDisplay { get; init; }

        [Range(0, int.MaxValue,ErrorMessage ="Price Cant be negative number")]
        public int ProductPrice { get; init; }
    }
}
