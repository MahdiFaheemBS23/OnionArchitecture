using Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllPersons();
        Task<Person> GetPersonById(int id);
        Task<int> AddPerson(Person entity);
        Task<int> UpdatePerson(Person entity);
        Task<int> RemovePerson(Person entity);
    }
}
