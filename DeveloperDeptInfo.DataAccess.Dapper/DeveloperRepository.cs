using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDeptInfo.DataAccess.Dapper
{
    class DeveloperRepository
    {
        protected readonly IConfiguration _config; 

        public DeveloperRepository(IConfiguration config)
        {
            _config = config;
        }

        //Create an IDB connection object to 
        
    }
}
