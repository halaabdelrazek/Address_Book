using DataAL.Data.Context;
using DataAL.Data.DatabaseModels;
using DataAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAL.Repositories.ContactRepository
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        private readonly AddressBookContext _context;

        public ContactRepository(AddressBookContext context) : base(context)
        {
            _context = context;
        }
    }
}
