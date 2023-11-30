using AutoMapper;
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
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public CustomerService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public CustomerDTO CreateCustomer(CustomerForManipulationDTO customerForManipulation, DateOnly birth)
        {
            //Проверка на GenderI, что такой гендер есть в БД
            var customer = _mapper.Map<Customer>(customerForManipulation);
            customer.CustomerBirth = birth;

            _repositoryManager.Customer.CreateCustomer(customer);
            _repositoryManager.Save();

            var customerToReturn = _mapper.Map<CustomerDTO>(customer);
            return customerToReturn;
        }

        public void DeleteCustomer(Guid customerId, bool trackChanges)
        {
            var customer = GetCustomerAndCheckIfItExist(customerId, trackChanges);

            _repositoryManager.Customer.DeleteCustomer(customer);
            _repositoryManager.Save();
        }

        public CustomerDTO GetCustomer(Guid customerId, bool trackChanges)
        {
            var customer = GetCustomerAndCheckIfItExist(customerId, trackChanges);
            var customerToReturn = _mapper.Map<CustomerDTO>(customer);
            return customerToReturn;
        }

        public IEnumerable<CustomerDTO> GetCustomers(bool trackChanges)
        {
            var customers = _repositoryManager.Customer.GetCustomers(trackChanges);
            var customersToReturn =_mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return customersToReturn;
        }

        public CustomerDTO UpdateCustomer(Guid customerId,CustomerForManipulationDTO customerForManipulation, bool trackChanges)
        {
            var customer = GetCustomerAndCheckIfItExist(customerId, trackChanges);
            _mapper.Map(customerForManipulation, customer);
            _repositoryManager.Save();

            var customerToReturn = _mapper.Map<CustomerDTO>(customer);
            return customerToReturn;
        }

        private Customer GetCustomerAndCheckIfItExist(Guid customerId, bool trackChanges)
        {
            var customer = _repositoryManager.Customer.GetCustomer(customerId, trackChanges);
            if (customer is null)
                throw new CustomerNotFoundException(customerId);
            return customer;
        }
    }
}
