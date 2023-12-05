using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(SitshophomeContext context)
            : base(context) 
        {       
        }

        public void CreateCustomer(Customer customer) => Create(customer);

        public void DeleteCustomer(Customer customer) => Delete(customer);

        public Customer GetCustomer(Guid customerId, bool trackChanges) =>
            FindByContidion(x => x.CustomerId.Equals(customerId), trackChanges)
            .SingleOrDefault();

        public Customer GetCustomerByEmailAndPassword(string email, string password, bool trackChanges) =>
            FindByContidion(x => x.CustomerEmail.Equals(email)
            && x.CustomerPassword.Equals(password), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Customer> GetCustomers(bool trackChanges) =>
            FindAll(trackChanges).ToList();
    }
}
