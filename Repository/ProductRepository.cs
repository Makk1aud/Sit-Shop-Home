using Contracts;
using Entities.Models;
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

        public IEnumerable<Product> GetProducts(bool trackChanges) => 
            FindAll(trackChanges)
            .ToList();
    }
}
