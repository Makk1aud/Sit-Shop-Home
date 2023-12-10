using Contracts;
using Entities.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utility
{
    public class EntityChecker
    {
        private readonly IRepositoryManager _repositoryManager;
        public EntityChecker(IRepositoryManager repositoryManager)
        {
            _repositoryManager= repositoryManager;
        }

        public Customer GetCustomerAndCheckIfItExist(Guid customerId, bool trackChanges)
        {
            var customer = _repositoryManager.Customer.GetCustomer(customerId, trackChanges);
            return GetEntityOrGenerateNotFoundException<Customer>(customer, customerId);
        }

        public Gender GetGenderAndCheckIfItExist(Guid genderId, bool trackChanges)
        {
            var gender = _repositoryManager.Gender.GetGender(genderId, trackChanges);
            return GetEntityOrGenerateNotFoundException<Gender>(gender, genderId);
        }

        public Product GetProductAndCheckIfItExist(Guid productId, bool trackChanges)
        {
            var product = _repositoryManager.Product.GetProduct(productId, trackChanges);
            return GetEntityOrGenerateNotFoundException<Product>(product, productId);
        }

        public Productcategory GetProductCategoryAndCheckIfItExist(Guid categoryId, bool trackChanges)
        {
            var category = _repositoryManager.ProductCategory.GetProductCategory(categoryId, trackChanges);
            return GetEntityOrGenerateNotFoundException<Productcategory>(category, categoryId);
        }

        //This method check entity and if entity is not null it return
        private T GetEntityOrGenerateNotFoundException<T>(T entity, Guid id)
        {
            if(entity is null)
                throw new GenericNotFoundException<T>(id);
            return entity;
        }
    }
}
