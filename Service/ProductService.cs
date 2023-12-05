﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
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

        public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public ProductDTO CreateProduct(ProductForManipulationDTO productForManipulation)
        {
            var product = _mapper.Map<Product>(productForManipulation);
            //Проверка на категорию
            _repositoryManager.Product.CreateProduct(product);
            _repositoryManager.Save();

            var productToReturn = _mapper.Map<ProductDTO>(product);
            return productToReturn;
        }

        public void DeleteProduct(Guid productId, bool trackChanges)
        {
            var product = CheckAndGetProductIfItExist(productId, trackChanges);
            _repositoryManager.Product.DeleteProduct(product);
            _repositoryManager.Save();
        }

        public ProductDTO GetProduct(Guid productId, bool trackChanges)
        {
            var product = CheckAndGetProductIfItExist(productId, trackChanges);
            var productToReturn = _mapper.Map<ProductDTO>(product);
            return productToReturn;
        }

        public IEnumerable<ProductDTO> GetProducts(bool trackChanges)
        {
            var products = _repositoryManager
                .Product
                .GetProducts(trackChanges);
            var productsToReturn = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return productsToReturn;
        }

        public ProductDTO UpdateProduct(Guid productId, ProductForManipulationDTO productForManipulation, bool trackChanges)
        {
            var product = CheckAndGetProductIfItExist(productId, trackChanges);
            //var productCategory Проверка категории
            _mapper.Map(productForManipulation,product);
            _repositoryManager.Save();

            var productToReturn = _mapper.Map<ProductDTO>(product);
            return productToReturn;
        }

        private Product CheckAndGetProductIfItExist(Guid productId, bool trackChanges)
        {
            var product = _repositoryManager.Product.GetProduct(productId, trackChanges);
            if (product is null)
                throw new GenericNotFoundException<Product>(productId);
            
            return product;
        }
    }
}
