using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers(bool trackChanges);
        Customer GetCustomer(Guid customerId, bool trackChanges);
        void DeleteCustomer(Customer customer);
        void CreateCustomer(Customer customer);
        Customer GetCustomerByEmailAndPassword(string email, string password, bool trackChanges);
    }
}
