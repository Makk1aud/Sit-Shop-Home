﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class ProductsParameters : RequestParameters
    {
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = int.MaxValue;
        public string? SearchName { get; set; }
        public Guid ProductCategoryId { get; set; }
        public bool ValidRange => MaxPrice > MinPrice;
    }
}
