using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductCategoryRepository : RepositoryBase<Productcategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(SitshophomeContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateProductCategory(Productcategory category) => Create(category);

        public void DeleteProductCategory(Productcategory category) => Delete(category);

        public IEnumerable<Productcategory> GetProductCategories(bool trackChanges) =>
            FindAll(trackChanges)
            .ToList();

        public Productcategory GetProductCategory(Guid categoryId, bool trackChanges) =>
            FindByContidion(x => x.ProductCategoryId.Equals(categoryId), trackChanges)
            .SingleOrDefault();
    }
}
