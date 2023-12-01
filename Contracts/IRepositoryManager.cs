using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICustomerRepository Customer { get; }
        IGenderRepository Gender { get; }
        void Save();
    }
}
