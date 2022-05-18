using AddressBookBL.DTOs.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookBL.DTOs.JobTitle
{
    public class JobTitleReadDTO
    {
        public Guid JobTitleId { get; init; }
        public string JobTitleName { get; init; }

        public ICollection<ChildContactDTO> Contacts { get; init; }
    }
}
