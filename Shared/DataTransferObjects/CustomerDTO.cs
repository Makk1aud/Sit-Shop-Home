using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class CustomerDTO()
    {
        public Guid CustomerId { get; init; }

        public string? CustomerFullName { get; init; }

        public string? CustomerPhone { get; init; }

        public string? CustomerEmail { get; init; }

        public Guid GenderId { get; init; }

        public string? CustomerPassword { get; init; }

        public DateOnly CustomerBirth { get; init; }
    }
}
