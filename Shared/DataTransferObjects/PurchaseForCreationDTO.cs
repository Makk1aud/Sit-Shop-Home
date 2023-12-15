using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class PurchaseForCreationDTO
    {
        [Required(ErrorMessage ="Field ProductId is required")]
        public Guid? ProductId { get; init; }

        [Required(ErrorMessage = "Filed PurchaseDate is required")]
        public DateTime PurchaseDate { get; init; }

        [Required(ErrorMessage = "Filed PurchaseCard is required")]
        [MaxLength(16, ErrorMessage = "Max chars for fild PurchaseCard is 16")]
        public string? PurchaseCard { get; init; }
    }
}
