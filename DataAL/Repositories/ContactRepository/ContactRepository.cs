using DataAL.Data.Context;
using DataAL.Data.DatabaseModels;
using DataAL.Data.FilterContact;
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

        public List<Contact> GetAllFiltered(FilteredContactDTO filteredContact)
        {
            var result = _context.Contacts.Where(c =>
         c.Username.Contains(filteredContact.fullNameQuery) &
         c.Address.Contains(filteredContact.addressQuery) &
         c.Email.Contains(filteredContact.emailQuery) &
         c.Phone.Contains(filteredContact.phoneQuery) &

         (string.IsNullOrEmpty(filteredContact.titleQuery) | c.JobTitle.JobTitleId.ToString() == filteredContact.titleQuery) &
         (string.IsNullOrEmpty(filteredContact.departmentQuery) | c.Department.DepartmentId.ToString() == filteredContact.departmentQuery) &
         (string.IsNullOrEmpty(filteredContact.ageQuery) | c.Age == filteredContact.ageQuery) &
         (filteredContact.To == null  | c.DateOfBirth <= filteredContact.To) &
         (filteredContact.From == null | c.DateOfBirth >= filteredContact.From)

         ).ToList();

           
            return result;
        }
    }
}
