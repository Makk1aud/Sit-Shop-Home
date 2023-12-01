using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenderRepository : RepositoryBase<Gender>, IGenderRepository
    {
        public GenderRepository(SitshophomeContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateGender(Gender gender) => Create(gender);

        public void DeleteGender(Gender gender) => Delete(gender);

        public Gender GetGender(Guid genderId, bool trackChanges) => 
            FindByContidion(x => x.GenderId.Equals(genderId), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Gender> GetGenders(bool trackChanges) =>
            FindAll(trackChanges)
            .ToList();
    }
}
