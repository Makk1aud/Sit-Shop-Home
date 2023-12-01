using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetCustomers(bool trackChanges);
        CustomerDTO GetCustomer(Guid customerId, bool trackChanges);
        CustomerDTO CreateCustomer(CustomerForManipulationDTO customerForManipulation, DateOnly birth);
        CustomerDTO UpdateCustomer(Guid customerId, CustomerForManipulationDTO customerForManipulation, bool trackChanges, DateOnly? birth = null);
        void DeleteCustomer(Guid customerId, bool trackChanges);
    }
}
