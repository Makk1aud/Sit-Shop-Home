using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IJsonSendRequest<T>
    {
        T? GetObject(Guid id);
        IEnumerable<T>? GetAllObject();
        void DeleteObject(Guid id);
    }
}