using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string ProductTitle { get; set; } = null!;

    public Guid ProductCategoryId { get; set; }

    public string ProductDescription { get; set; } = null!;

    public string ProductImage { get; set; } = null!;

    public bool? ProductDisplay { get; set; }

    public virtual Productcategory ProductCategory { get; set; } = null!;

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
