using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperDeptInfo.Domain
{
    public class Developer
    {
        public int Id { get; set; }
        public string DeveloperName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public DateTime JoinDate { get; set; }

    }
}
