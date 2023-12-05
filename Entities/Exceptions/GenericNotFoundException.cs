using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class GenericNotFoundException<T> : NotFoundException
    {
        public GenericNotFoundException(Guid id)
            : base($"object {typeof(T).Name} with id: {id} not found")
        {
        }
    }
}
