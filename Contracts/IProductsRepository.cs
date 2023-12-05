using Entities.Models;
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
        IEnumerable<Product> GetProducts(bool trackChanges);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
