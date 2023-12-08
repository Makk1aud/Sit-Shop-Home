using System;
using System.Collections.Generic;

namespace Entities.Models;
public partial class Gender
{
    public Guid GenderId { get; set; }

    public string GenderTitle { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
