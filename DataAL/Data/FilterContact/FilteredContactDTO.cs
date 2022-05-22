using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAL.Data.FilterContact
{
    public class FilteredContactDTO
    {

        public string? fullNameQuery { get; set; }
        public string? titleQuery { get; set; }
        public string? departmentQuery { get; set; }

        public string? phoneQuery { get; set; }
        public string? addressQuery { get; set; }
        public string? emailQuery { get; set; }
        public string? ageQuery { get; set; }

        public DateTime? To { get; set; }

        public DateTime? From { get; set; }
    }
}
