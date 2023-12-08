using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class ProductDTO
    {
        public Guid ProductId { get; init; }

        public string? ProductTitle { get; init; }

        public Guid ProductCategoryId { get; init; }

        public string? ProductDescription { get; init; }

        public string? ProductImage { get; init; }

        public bool? ProductDisplay { get; init; }

        public int ProductPrice { get; init; }
    }
}
