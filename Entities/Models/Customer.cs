using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? CustomerSurname { get; set; }

    public string? CustomerPhone { get; set; }

    public string CustomerEmail { get; set; } = null!;

    public Guid GenderId { get; set; }

    public string CustomerPassword { get; set; } = null!;

    public DateOnly CustomerBirth { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
