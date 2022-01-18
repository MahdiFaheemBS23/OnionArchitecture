using Data;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepo;

        public PersonService(IRepository<Person> personRepo)
        {
            _personRepo = personRepo;
        }

        public async Task<List<Person>> GetAllPersons()
        {
            return await _personRepo.GetAll();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _personRepo.GetById(id);
        }

        public async Task<int> AddPerson(Person person)
        {
            return await _personRepo.Add(person);
        }

        public async Task<int> UpdatePerson(Person person)
        {
            return await _personRepo.Update(person);
        }

        public async Task<int> RemovePerson(Person person)
        {
            return await _personRepo.Remove(person);
        }
    }
}
