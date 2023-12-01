using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IGenderService
    {
        IEnumerable<ReferenceDTO> GetGenders(bool trackChanges);
        ReferenceDTO GetGender(Guid genderId, bool trackChanges);
        ReferenceDTO UpdateGender(Guid genderId, GenderForManipulationDTO genderForManipulation, bool trackChanges);
        void DeleteGender(Guid genderId, bool trackChanges);
        ReferenceDTO CreateGender(GenderForManipulationDTO genderForManipulation);
    }
}
