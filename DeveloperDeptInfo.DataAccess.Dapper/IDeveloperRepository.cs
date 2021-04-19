using DeveloperDeptInfo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDeptInfo.DataAccess.Dapper
{
    public interface IDeveloperRepository
    {
        Task<IEnumerable<Developer>> GetAllDeveloperAsync();
        Task<Developer> GetDeveloperByIdAsync(int Id);
        Task<Developer> GetDeveloperByEmail(string Email);
        void AddDeveloper(Developer developer);
        void UpdateDeveloper(Developer developer);
        void DeleteDeveloper(int id);
    }
}
