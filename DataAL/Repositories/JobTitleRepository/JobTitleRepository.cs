using DataAL.Data.Context;
using DataAL.DatabaseModels;
using DataAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAL.Repositories.JobTitleRepository
{
    public class JobTitleRepository: GenericRepository<JobTitle>,IJobTitleRepository
    {
        private readonly AddressBookContext _context;

        public JobTitleRepository(AddressBookContext context) : base(context)
        {
            _context = context;
        }
    }

   
}
