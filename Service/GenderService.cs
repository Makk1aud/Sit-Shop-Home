using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Service.Utility;
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
        private readonly EntityChecker _entityChecker;

        public GenderService(IRepositoryManager repositoryManger, IMapper mapper, EntityChecker entityChecker)
        {
            _repositoryManger = repositoryManger;
            _mapper = mapper;
            _entityChecker = entityChecker;
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
            var gender = _entityChecker.GetGenderAndCheckIfItExist(genderId, trackChanges);
            _repositoryManger.Gender.DeleteGender(gender);
            _repositoryManger.Save();
        }

        public ReferenceDTO GetGender(Guid genderId, bool trackChanges)
        {
            var gender = _entityChecker.GetGenderAndCheckIfItExist(genderId, trackChanges);
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
            var gender = _entityChecker.GetGenderAndCheckIfItExist(genderId, trackChanges);
            _mapper.Map(genderForManipulation, gender);
            _repositoryManger.Save();

            var genderToReturn = _mapper.Map<ReferenceDTO>(gender);
            return genderToReturn;
        }
    }
}
