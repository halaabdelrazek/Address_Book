using DataAL.Data.DatabaseModels;
using DataAL.Repositories.GenericRepository;

namespace DataAL.Repositories.ContactRepository
{
    public interface IContactRepository: IGenericRepository<Contact>
    {
        List<Contact> GetAllFiltered(string fullName, string title);

    }
}