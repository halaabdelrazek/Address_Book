﻿using AddressBookBL.ContactBL;
using AddressBookBL.DTOs.Contact;
using DataAL.Data.DatabaseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Address_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactBL contactBL;

        public ContactController(IContactBL contactBL)
        {
            this.contactBL = contactBL;
        }
        [Route("FiltersContact")]
        [HttpPost]
        public ActionResult<IEnumerable<ContactReadDTO>> GetContactFiltered(AllContactFilterDTO request)
        {

            return contactBL.GetFilteredContacts(request);

        }
        // GET: api/Contacts
        [HttpGet]
        public ActionResult<IEnumerable<ContactReadDTO>> GetContact()
        {

            return contactBL.GetContacts();

        }
        // POST: api/Contact
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ContactReadDTO> PostContact(ContactDTO contact)
        {
            var ContactDTO = contactBL.Post(contact);
            return Created("Contact Created",ContactDTO);
        }


        // PUT: api/Contacts/id
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<ContactReadDTO> PutContact(Guid id, ContactDTO contact)
        {
            if (contactBL.PutContact(id, contact) == -1)
            {
                return BadRequest();
            }


            if (contactBL.PutContact(id, contact) == 0)
            {
                return NotFound();
            }

            var returnedContact = contactBL.GetById(id);



            return Ok(returnedContact);
        }


        // DELETE: api/Contact/id
        [HttpDelete("{id}")]
        public ActionResult<ContactReadDTO> DeleteContact(Guid id)
        {
            var returnedContact = contactBL.DeleteContact(id);

            return Ok(returnedContact);
        }

    }
}
