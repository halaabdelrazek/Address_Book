using DataAL.Data.Context;
using DataAL.DatabaseModels;
using DataAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAL.Repositories.DepartmentRepository
{
    public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
    {
        private readonly AddressBookContext _context;

        public DepartmentRepository(AddressBookContext context) : base(context)
        {
            _context = context;
        }

    }
}
