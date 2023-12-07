using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class ProductCategoryForManipulationDTO
    {
        [Required(ErrorMessage ="CategoryTitle is required field")]
        [MaxLength(100, ErrorMessage ="Max length for CategoryTitle field is 100 chars")]
        public string? CategoryTitle { get; init; }
    }
}
