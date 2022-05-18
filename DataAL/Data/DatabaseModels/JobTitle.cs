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
            Users = new HashSet<User>();
        }
        public Guid JobTitleId { get; set; }

        public string JobTitleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
