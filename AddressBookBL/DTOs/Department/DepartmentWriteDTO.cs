using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookBL.DTOs.Department
{
    public class DepartmentWriteDTO
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; init; }

    }
}
