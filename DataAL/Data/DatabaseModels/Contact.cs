using DataAL.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAL.Data.DatabaseModels
{
    public class Contact
    {
        public Guid ContactId { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public string Image { get; set; }

        public string Age { get; set; }

        public Guid DepartmentId { get; set; }

        public virtual Department Department { get; set; }


        public Guid JobTitleId { get; set; }

        public virtual JobTitle JobTitle { get; set; }
    }
}
