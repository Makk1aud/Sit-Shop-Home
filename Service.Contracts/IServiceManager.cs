using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        ICustomerService Customer { get; }  
        IGenderService Gender { get; }
        IProductService Product { get; }
        IProductCategoryService ProductCategory { get; }
    }
}
