using DataAL.Data.DatabaseModels;
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
            Contacts = new HashSet<Contact>();
        }
        public Guid DepartmentId { get; set; }

        public string DeptmentName { get; set; }

        public ICollection<Contact> Contacts { get; set; }



    }
}
