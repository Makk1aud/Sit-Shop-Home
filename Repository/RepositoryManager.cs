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
        private Lazy<ICustomerRepository> customerRepository;

        public RepositoryManager(SitshophomeContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(_repositoryContext));
        }

        public ICustomerRepository Customer => customerRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();
    }
}
