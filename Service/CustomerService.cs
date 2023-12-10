using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Service.Utility;
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
        private readonly IMapper _mapper;
        private readonly EntityChecker _entityChecker; 

        public CustomerService(IRepositoryManager repositoryManager, IMapper mapper, EntityChecker entityChecker)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _entityChecker = entityChecker;
        }

        public CustomerDTO CreateCustomer(CustomerForManipulationDTO customerForManipulation, DateOnly birth)
        {
            var customer = _mapper.Map<Customer>(customerForManipulation);
            //CheckGenderIfItExist((Guid)customerForManipulation.GenderId, trackChanges:false);
            _entityChecker.GetGenderAndCheckIfItExist((Guid)customerForManipulation.GenderId, trackChanges: false);
            
            customer.CustomerBirth = birth;

            _repositoryManager.Customer.CreateCustomer(customer);
            _repositoryManager.Save();

            var customerToReturn = _mapper.Map<CustomerDTO>(customer);
            return customerToReturn;
        }

        public void DeleteCustomer(Guid customerId, bool trackChanges)
        {
            var customer = _entityChecker.GetCustomerAndCheckIfItExist(customerId, trackChanges);
            //_entityChecker.GetCustomerAndCheckIfItExist(customerId, trackChanges, trackChanges);
            _repositoryManager.Customer.DeleteCustomer(customer);
            _repositoryManager.Save();
        }

        public CustomerDTO GetCustomer(Guid customerId, bool trackChanges)
        {
            //var customer = GetCustomerAndCheckIfItExist(customerId, trackChanges);
            var customer = _entityChecker.GetCustomerAndCheckIfItExist(customerId,trackChanges);
            var customerToReturn = _mapper.Map<CustomerDTO>(customer);
            return customerToReturn;
        }

        public IEnumerable<CustomerDTO> GetCustomers(bool trackChanges)
        {
            var customers = _repositoryManager.Customer.GetCustomers(trackChanges);
            var customersToReturn =_mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return customersToReturn;
        }

        public CustomerDTO UpdateCustomer(Guid customerId, CustomerForManipulationDTO customerForManipulation, bool trackChanges, DateOnly? birth = null)
        {
            var customer = _entityChecker.GetCustomerAndCheckIfItExist(customerId, trackChanges);
            //CheckGenderIfItExist((Guid)customerForManipulation.GenderId, trackChanges);
            _entityChecker.GetGenderAndCheckIfItExist((Guid)customerForManipulation.GenderId, trackChanges: false);

            _mapper.Map(customerForManipulation, customer);

            customer.CustomerBirth = birth.HasValue ? (DateOnly)birth : customer.CustomerBirth; 
            _repositoryManager.Save();

            var customerToReturn = _mapper.Map<CustomerDTO>(customer);
            return customerToReturn;
        }

        public CustomerDTO GetCustomerByEmailAndPassword(string email, string password, bool trackChanges)
        {
            var customer = _repositoryManager.Customer.GetCustomerByEmailAndPassword(email, password, trackChanges);
            if(customer is null)
                throw new GenericNotFoundException<Customer>($"Customer with email:{email} and password:{password} not found");

            var customerToReturn = _mapper.Map<CustomerDTO>(customer);

            return customerToReturn;
        }
    }
}
