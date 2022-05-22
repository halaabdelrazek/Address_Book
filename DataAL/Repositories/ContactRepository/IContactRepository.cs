using DataAL.Data.DatabaseModels;
using DataAL.Data.FilterContact;
using DataAL.Repositories.GenericRepository;

namespace DataAL.Repositories.ContactRepository
{
    public interface IContactRepository: IGenericRepository<Contact>
    {
        List<Contact> GetAllFiltered(FilteredContactDTO filteredContact);

    }
}