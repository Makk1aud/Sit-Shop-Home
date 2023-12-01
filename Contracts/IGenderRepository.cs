using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGenderRepository
    {
        IEnumerable<Gender> GetGenders(bool trackChanges);
        Gender GetGender(Guid genderId, bool trackChanges);
        void CreateGender(Gender gender);
        void DeleteGender(Gender gender);
    }
}
