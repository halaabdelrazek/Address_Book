using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookBL.DTOs.JobTitle
{
    public class JobTitleWriteDTO
    {
        public Guid JobTitleId { get; set; }
        public string JobTitleName { get; init; }
    }
}
