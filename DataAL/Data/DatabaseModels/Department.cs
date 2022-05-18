using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAL.DatabaseModels
{
    public class Department
    {
        public Department()
        {
            Users = new HashSet<User>();
        }
        public Guid DepartmentId { get; set; }

        public string DeptmentName { get; set; }

        public ICollection<User> Users { get; set; }



    }
}
