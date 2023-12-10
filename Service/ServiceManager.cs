using AutoMapper;
using Contracts;
using Service.Contracts;
using Service.Utility;
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
        private readonly Lazy<IGenderService> _genderService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IProductCategoryService> _productCategoryService;
        public ServiceManager(IMapper mapper, IRepositoryManager repositoryManager)
        {
            var entityChecker = new EntityChecker(repositoryManager);

            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager, mapper, entityChecker));
            _genderService = new Lazy<IGenderService>(() => new GenderService(repositoryManager, mapper, entityChecker));
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper, entityChecker));
            _productCategoryService = new Lazy<IProductCategoryService>(() => new ProductCategoryService(repositoryManager, mapper, entityChecker));
        }
        public ICustomerService Customer => _customerService.Value;

        public IGenderService Gender => _genderService.Value;

        public IProductService Product => _productService.Value;

        public IProductCategoryService ProductCategory => _productCategoryService.Value;
    }
}
