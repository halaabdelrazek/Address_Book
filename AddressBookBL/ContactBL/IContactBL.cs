using AddressBookBL.DTOs.Contact;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookBL.ContactBL
{
    public interface IContactBL
    {
        ActionResult<IEnumerable<ContactReadDTO>> GetContacts();
        ActionResult<IEnumerable<ContactReadDTO>> GetFilteredContacts(AllContactFilterDTO request);
        ContactReadDTO Post(ContactDTO _contact);

        ContactReadDTO GetById(Guid id);
        ContactReadDTO DeleteContact(Guid id);

        int PutContact(Guid id, ContactDTO _contact);
        void AsssignImageToContact(Guid id, string imagePath);

    }
}