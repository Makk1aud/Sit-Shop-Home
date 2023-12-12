using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class PurchaseDTO
    {
        public Guid PurchaseId { get; init; }

        public Guid CustomerId { get; init; }

        public Guid ProductId { get; init; }

        public DateTime PurchaseDate { get; init; }

        public string? PurchaseCard { get; init; }
    }
}
