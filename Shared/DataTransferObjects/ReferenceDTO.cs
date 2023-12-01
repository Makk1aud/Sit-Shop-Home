using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class ReferenceDTO
    {
        public Guid id { get; init; }
        public string title { get; init; }
    }
}
