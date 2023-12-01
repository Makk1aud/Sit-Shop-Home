using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class GenderForManipulationDTO
    {
        [Required(ErrorMessage ="GenderTitle field is required")]
        [MaxLength(15, ErrorMessage ="Max chars for GenderTitle is 15 chars")]
        public string? GenderTitle { get; init; }
    }
}
