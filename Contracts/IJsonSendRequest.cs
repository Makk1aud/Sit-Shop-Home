using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IJsonSendRequest<T>
    {
        T? GetObject(Guid id, string? token = null);
        IEnumerable<T>? GetAllObject(string? token = null);
        void DeleteObject(Guid id, string? token = null);
    }
}