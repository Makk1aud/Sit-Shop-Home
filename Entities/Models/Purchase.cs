using Entities.Models;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Purchase
{
    public Guid PurchaseId { get; set; }

    public Guid CustomerId { get; set; }

    public Guid ProductId { get; set; }

    public DateTime PurchaseDate { get; set; }

    public string PurchaseCard { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
