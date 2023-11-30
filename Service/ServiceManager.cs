using AutoMapper;
using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICustomerService> _customerService;
        public ServiceManager(IMapper mapper, IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager, loggerManager, mapper));
        }
        public ICustomerService Customer => _customerService.Value;
    }
}
