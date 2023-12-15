using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Product> SearchFilter(this IQueryable<Product> products, string? searchName)
        {
            if(string.IsNullOrEmpty(searchName))
                return products;

            var lowerCaseSearch = searchName.Trim().ToLower();

            return products.Where(x => x.ProductTitle.ToLower().Contains(lowerCaseSearch));
        }

        public static IQueryable<Product> PriceFilter(this IQueryable<Product> products, uint minPrice, uint maxPrice) =>
            products.Where(x => x.ProductPrice <= maxPrice && x.ProductPrice >= minPrice);

        public static IQueryable<Product> CategoryFilter(this IQueryable<Product> products, Guid? categoryId) =>
            categoryId.Equals(Guid.Empty) ? products : products.Where(x => x.ProductCategoryId.Equals(categoryId));
    }
}
