using System;
using System.Collections.Generic;

namespace Repository;

public partial class Productcategory
{
    public Guid ProductCategoryId { get; set; }

    public string CategoryTitle { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
