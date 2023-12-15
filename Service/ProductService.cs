using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Service.Utility;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly EntityChecker _entityChecker;

        public ProductService(IRepositoryManager repositoryManager, IMapper mapper, EntityChecker entityChecker)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _entityChecker = entityChecker;
        }

        public ProductDTO CreateProduct(ProductForManipulationDTO productForManipulation)
        {
            var product = _mapper.Map<Product>(productForManipulation);
            _entityChecker.GetProductCategoryAndCheckIfItExist((Guid)productForManipulation.ProductCategoryId, trackChanges: false);
            _repositoryManager.Product.CreateProduct(product);
            _repositoryManager.Save();

            var productToReturn = _mapper.Map<ProductDTO>(product);
            return productToReturn;
        }

        public void DeleteProduct(Guid productId, bool trackChanges)
        {
            var product = _entityChecker.GetProductAndCheckIfItExist(productId, trackChanges);
            _repositoryManager.Product.DeleteProduct(product);
            _repositoryManager.Save();
        }

        public ProductDTO GetProduct(Guid productId, bool trackChanges)
        {
            var product = _entityChecker.GetProductAndCheckIfItExist(productId, trackChanges);
            var productToReturn = _mapper.Map<ProductDTO>(product);
            return productToReturn;
        }

        public (IEnumerable<ProductDTO> products, MetaData metaData) GetProducts(ProductsParameters productsParameters, bool trackChanges)
        {
            if (!productsParameters.ValidRange)
                throw new GenericBadRequestException<Product>("Max price cant be higher than min price");

            var productsWithMetaData = _repositoryManager.Product.GetProducts(productsParameters, trackChanges);

            var productsToReturn = _mapper.Map<IEnumerable<ProductDTO>>(productsWithMetaData);

            return (products: productsToReturn, metaData: productsWithMetaData.MetaData);
        }

        public ProductDTO UpdateProduct(Guid productId, ProductForManipulationDTO productForManipulation, bool trackChanges)
        {
            var product = _entityChecker.GetProductAndCheckIfItExist(productId, trackChanges);
            _entityChecker.GetProductCategoryAndCheckIfItExist((Guid)productForManipulation.ProductCategoryId, trackChanges : false);

            _mapper.Map(productForManipulation,product);
            _repositoryManager.Save();

            var productToReturn = _mapper.Map<ProductDTO>(product);
            return productToReturn;
        }
    }
}
