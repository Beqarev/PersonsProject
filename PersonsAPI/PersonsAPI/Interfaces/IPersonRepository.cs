using PersonsAPI.Models;

namespace PersonsAPI.Interfaces;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetPersons();
    Task<Person> AddPerson(Person person);
    
}