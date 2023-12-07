using Contracts;
using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(SitshophomeContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateProduct(Product product) => Create(product);

        public void DeleteProduct(Product product) => Delete(product);

        public Product GetProduct(Guid productId, bool trackChanges) =>
            FindByContidion(x => x.ProductId.Equals(productId), trackChanges)
            .SingleOrDefault();

        public PagedList<Product> GetProducts(ProductsParameters productsParameters, bool trackChanges)
        {
            var products = FindAll(trackChanges)
                .Skip((productsParameters.PageNumber - 1) * productsParameters.PageSize)
                .Take(productsParameters.PageSize)
                .ToList();
            var count = FindAll(trackChanges)
                .Count();

            return new PagedList<Product>(products, count, productsParameters.PageNumber, productsParameters.PageSize);
        }
    }
}
