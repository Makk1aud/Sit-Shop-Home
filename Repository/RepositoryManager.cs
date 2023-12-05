using Contracts;
using System;
using System.Collections.Generic;
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

        public RepositoryManager(SitshophomeContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(_repositoryContext));
            _genderRepository = new Lazy<IGenderRepository>(() => new GenderRepository(_repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_repositoryContext));
        }

        public ICustomerRepository Customer => _customerRepository.Value;

        public IGenderRepository Gender => _genderRepository.Value;

        public IProductRepository Product => _productRepository.Value;

        //Сделать обработчик ошибок при сохранении в БД
        public void Save() => _repositoryContext.SaveChanges();
    }
}
