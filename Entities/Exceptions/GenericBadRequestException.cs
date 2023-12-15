using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class GenericBadRequestException<T> : BadRequestException
    {
        public GenericBadRequestException(string message)
            : base($"{typeof(T).Name} {message}")
        {

        }

        public GenericBadRequestException(Guid id, string message) 
            : base($"{message} with id:{id}")
        {

        }
    }
}
