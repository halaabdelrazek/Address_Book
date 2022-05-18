using DataAL.Data.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAL.DatabaseModels
{
    public class JobTitle
    {
        public JobTitle()
        {
            Contacts = new HashSet<Contact>();
        }
        public Guid JobTitleId { get; set; }

        public string JobTitleName { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
