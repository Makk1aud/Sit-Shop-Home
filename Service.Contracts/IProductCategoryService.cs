using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProductCategoryService
    {
        IEnumerable<ReferenceDTO> GetProductsCategories(bool trackChanges);
        ReferenceDTO GetProductCategory(Guid categoryId, bool trackChanges);
        ReferenceDTO UpdateProductCategory(Guid categoryId, ProductCategoryForManipulationDTO categoryForManipulation, bool trackChanges);
        void DeleteProductCategory(Guid categoryId, bool trackChanges);
        ReferenceDTO CreateProductCategory(ProductCategoryForManipulationDTO categoryForManipulation);
    }
}
