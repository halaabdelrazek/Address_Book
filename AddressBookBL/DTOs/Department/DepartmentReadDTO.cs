using AddressBookBL.DTOs.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookBL.DTOs.Department
{
    public class DepartmentReadDTO
    {
        public Guid DepartmentId { get; init; }
        public string DepartmentName { get; init; }

        public  ICollection<ChildContactDTO> Contacts { get; init; }

    }
}
