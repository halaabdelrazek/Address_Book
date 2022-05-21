using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookBL.DTOs.Contact
{
    public class AllContactFilterDTO
    {
        public string FullNameQuery { get; set; }
        public string TitleQuery { get; set; }
        public string  DepartmentId { get; set; }
    }
}
