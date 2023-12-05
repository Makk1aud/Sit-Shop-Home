using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProductService
    {
        ProductDTO GetProduct(Guid productId, bool trackChanges);
        IEnumerable<ProductDTO> GetProducts(bool trackChanges);
        ProductDTO UpdateProduct(Guid productId, ProductForManipulationDTO productForManipulation, bool trackChanges);
        ProductDTO CreateProduct(ProductForManipulationDTO productForManipulation);
        void DeleteProduct(Guid productId, bool trackChanges);
    }
}
