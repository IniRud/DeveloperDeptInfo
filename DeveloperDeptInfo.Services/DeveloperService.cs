using DeveloperDeptInfo.DataAccess.Dapper;
using DeveloperDeptInfo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDeptInfo.Services
{
    public class DeveloperService : IDeveloperService
    {
        protected readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }
        public void AddDeveloper(Developer developer)
        {
            _developerRepository.AddDeveloper(developer);
        }

        public void DeleteDeveloper(int id)
        {
            _developerRepository.DeleteDeveloper(id);
        }

        public Task<IEnumerable<Developer>> GetAllDeveloper()
        {
            return _developerRepository.GetAllDeveloperAsync();
        }

        public Task<Developer> GetDeveloperByEmail(string Email)
        {
            return _developerRepository.GetDeveloperByEmail(Email);
        }

        public Task<Developer> GetDeveloperById(int Id)
        {
            return _developerRepository.GetDeveloperByIdAsync(Id);
        }

        public void UpdateDeveloper(Developer developer)
        {
            _developerRepository.UpdateDeveloper(developer);
        }
    }
}
