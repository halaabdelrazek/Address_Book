using AddressBookBL.DTOs.Contact;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookBL.ContactBL
{
    public interface IContactBL
    {
        ActionResult<IEnumerable<ContactDTO>> GetContacts();
        ContactDTO Post(ContactDTO _contact);

        ActionResult<ContactDTO> GetById(Guid id);
        ContactDTO DeleteContact(Guid id);
        int PutContact(Guid id, ContactDTO _contact);

    }
}