using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductRepository
    {
        Product GetProduct(Guid productId, bool trackChanges);
        PagedList<Product> GetProducts(ProductsParameters productsParameters,bool trackChanges);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
