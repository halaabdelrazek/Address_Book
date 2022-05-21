using AddressBookBL.DTOs.Contact;
using AddressBookBL.DTOs.JobTitle;
using AutoMapper;
using DataAL.Data.Context;
using DataAL.Data.DatabaseModels;
using DataAL.DatabaseModels;
using DataAL.Repositories.ContactRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookBL.ContactBL
{
    public class ContactBL : IContactBL
    {
        private readonly IContactRepository contactRepo;
        private readonly IMapper _mapper;
        private readonly AddressBookContext context;

        public ContactBL(IContactRepository contactRepo, IMapper mapper, AddressBookContext _context)
        {
            this.contactRepo = contactRepo;
            _mapper = mapper;
            context = _context;
        }

        public ActionResult<IEnumerable<ContactReadDTO>> GetContacts()
        {
            var contactFromDB = contactRepo.GetAll();
            return _mapper.Map<List<ContactReadDTO>>(contactFromDB);

        }
        public ActionResult<IEnumerable<ContactReadDTO>> GetFilteredContacts(AllContactFilterDTO request)
        {
            var contactFromDB = contactRepo.GetAllFiltered(request.FullNameQuery,request.TitleQuery);
            return _mapper.Map<List<ContactReadDTO>>(contactFromDB);

        }
        public ContactReadDTO Post(ContactDTO _contact)
        {
            var contactToAdd = _mapper.Map<Contact>(_contact);

            var newContactDepartment = context.Departments.FirstOrDefault(i=>i.DepartmentId.ToString() ==_contact.DepartmentId);
            contactToAdd.Department = newContactDepartment;

            var newContactJobTitle = context.JobTitles.FirstOrDefault(i => i.JobTitleId.ToString() == _contact.JobTitleId);
            contactToAdd.JobTitle = newContactJobTitle;

            contactToAdd.ContactId = Guid.NewGuid();

            _contact.ContactId = contactToAdd.ContactId;


            context.Contacts.Add(contactToAdd);
            context.SaveChanges();


            return _mapper.Map<ContactReadDTO>(contactToAdd);
        }


        public ContactReadDTO GetById(Guid id)
        {
            var contactFromDB = context.Contacts.FirstOrDefault(c => c.ContactId == id);

            return _mapper.Map<ContactReadDTO>(contactFromDB);
        }

        public ContactReadDTO DeleteContact(Guid id)
        {
            var contactDeleted = contactRepo.GetById(id);


            contactRepo.Delete(id);
            contactRepo.SaveChanges();

            //Contact is deleted
            return _mapper.Map<ContactReadDTO>(contactDeleted);
             
        }

        public int PutContact(Guid id, ContactDTO _contact)
        {
            if (id != _contact.ContactId)
            {
                // retun -1 to ids not equal
                return -1;
            }

            var contactToEdit = contactRepo.GetById(id);
            if (contactToEdit is null)
            {
                // retun 0 to dept not found

                return 0;
            }


            _mapper.Map(_contact, contactToEdit);


            contactRepo.Update(contactToEdit);
            contactRepo.SaveChanges();

            // retun 1 to update dept done

            return 1;
        }
    }
}
