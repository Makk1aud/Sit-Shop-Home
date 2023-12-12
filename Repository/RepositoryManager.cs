using Contracts;
using Entities.Exceptions;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly SitshophomeContext _repositoryContext;
        private Lazy<ICustomerRepository> _customerRepository;
        private Lazy<IGenderRepository> _genderRepository;
        private Lazy<IProductRepository> _productRepository;
        private Lazy<IProductCategoryRepository> _productCategoryRepository;
        private Lazy<IPurchaseRepository> _purchaseRepository;

        public RepositoryManager(SitshophomeContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(_repositoryContext));
            _genderRepository = new Lazy<IGenderRepository>(() => new GenderRepository(_repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_repositoryContext));
            _productCategoryRepository = new Lazy<IProductCategoryRepository>(() => new ProductCategoryRepository(repositoryContext));
            _purchaseRepository = new Lazy<IPurchaseRepository>(() => new PurchaseRepository(_repositoryContext));
        }

        public ICustomerRepository Customer => _customerRepository.Value;

        public IGenderRepository Gender => _genderRepository.Value;

        public IProductRepository Product => _productRepository.Value;

        public IProductCategoryRepository ProductCategory => _productCategoryRepository.Value;

        public IPurchaseRepository Purchase => _purchaseRepository.Value;

        public void Save()
        {
            try
            {
                _repositoryContext.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                if(ex.GetBaseException() is PostgresException pgException)
                    switch(pgException.Code)
                    {
                        case "23505":
                            throw new DataBaseBadRequestException("Такой email уже существует");
                        default:
                            throw new DataBaseBadRequestException($"Ошибка при сохранении данных");
                    }
                else
                    throw new DataBaseBadRequestException($"Ошибка при сохранении данных");
            }
        }
    }
}
