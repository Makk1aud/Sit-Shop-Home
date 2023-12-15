using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Service.Utility;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly EntityChecker _entityChecker;

        public ProductCategoryService(IRepositoryManager repositoryManager, IMapper mapper, EntityChecker entityChecker)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _entityChecker = entityChecker;
        }

        public ReferenceDTO CreateProductCategory(ProductCategoryForManipulationDTO categoryForManipulation)
        {
            var category = _mapper.Map<Productcategory>(categoryForManipulation);
            _repositoryManager.ProductCategory.CreateProductCategory(category);
            _repositoryManager.Save();

            var categoryToReturn = _mapper.Map<ReferenceDTO>(category);
            return categoryToReturn;
        }

        public void DeleteProductCategory(Guid categoryId, bool trackChanges)
        {
            var category = _entityChecker.GetProductCategoryAndCheckIfItExist(categoryId, trackChanges);
            _repositoryManager.ProductCategory.DeleteProductCategory(category);
            _repositoryManager.Save();
        }

        public ReferenceDTO GetProductCategory(Guid categoryId, bool trackChanges)
        {
            var category = _entityChecker.GetProductCategoryAndCheckIfItExist(categoryId, trackChanges);
            var categoryToReturn = _mapper.Map<ReferenceDTO>(category);
            return categoryToReturn;
        }

        public IEnumerable<ReferenceDTO> GetProductsCategories(bool trackChanges)
        {
            var categories = _repositoryManager.ProductCategory.GetProductCategories(trackChanges);
            var categoriesToReturn = _mapper.Map<IEnumerable<ReferenceDTO>>(categories);
            return categoriesToReturn;
        }

        public ReferenceDTO UpdateProductCategory(Guid categoryId, ProductCategoryForManipulationDTO categoryForManipulation, bool trackChanges)
        {
            var category = _entityChecker.GetProductCategoryAndCheckIfItExist(categoryId, trackChanges);
            _mapper.Map(categoryForManipulation, category);
            _repositoryManager.Save();

            var categoryToReturn = _mapper.Map<ReferenceDTO>(category);
            return categoryToReturn;
        }
    }
}
