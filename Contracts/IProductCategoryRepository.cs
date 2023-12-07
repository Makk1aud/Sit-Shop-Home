using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductCategoryRepository
    {
        IEnumerable<Productcategory> GetProductCategories(bool trackChanges);
        Productcategory GetProductCategory(Guid categoryId, bool trackChanges);
        void CreateProductCategory(Productcategory category);
        void DeleteProductCategory(Productcategory category);
    }
}
