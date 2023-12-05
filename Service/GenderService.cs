using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GenderService : IGenderService
    {
        private readonly IRepositoryManager _repositoryManger;
        private readonly IMapper _mapper;

        public GenderService(IRepositoryManager repositoryManger, IMapper mapper)
        {
            _repositoryManger = repositoryManger;
            _mapper = mapper;
        }

        public ReferenceDTO CreateGender(GenderForManipulationDTO genderForManipulation)
        {
            var gender = _mapper.Map<Gender>(genderForManipulation);
            _repositoryManger.Gender.CreateGender(gender);
            _repositoryManger.Save();

            var genderToReturn = _mapper.Map<ReferenceDTO>(gender);
            return genderToReturn;
        }

        public void DeleteGender(Guid genderId, bool trackChanges)
        {
            var gender = GetGenderIfItExist(genderId, trackChanges);
            _repositoryManger.Gender.DeleteGender(gender);
            _repositoryManger.Save();
        }

        public ReferenceDTO GetGender(Guid genderId, bool trackChanges)
        {
            var gender = GetGenderIfItExist(genderId, trackChanges);
            var genderToReturn = _mapper.Map<ReferenceDTO>(gender);
            return genderToReturn;
        }

        public IEnumerable<ReferenceDTO> GetGenders(bool trackChanges)
        {
            var genders = _repositoryManger.Gender.GetGenders(trackChanges);
            var gendersToReturn = _mapper.Map<IEnumerable<ReferenceDTO>>(genders);
            return gendersToReturn;
        }

        public ReferenceDTO UpdateGender(Guid genderId, GenderForManipulationDTO genderForManipulation, bool trackChanges)
        {
            var gender = GetGenderIfItExist(genderId, trackChanges);
            _mapper.Map(genderForManipulation, gender);
            _repositoryManger.Save();

            var genderToReturn = _mapper.Map<ReferenceDTO>(gender);
            return genderToReturn;
        }

        private Gender GetGenderIfItExist(Guid genderId, bool trackChanges)
        {
            var gender = _repositoryManger.Gender.GetGender(genderId, trackChanges);
            if (gender is null)
                throw new GenericNotFoundException<Gender>(genderId);

            return gender;
        }
    }
}
