using Microsoft.EntityFrameworkCore;
using PersonsAPI.Data;
using PersonsAPI.Interfaces;
using PersonsAPI.Models;

namespace PersonsAPI.Repository;

public class PersonRepository : IPersonRepository
{
    private readonly DataContext _context;

    public PersonRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Person>> GetPersons()
    {
        return await _context.Persons.ToListAsync();
    }

    public async Task<Person> AddPerson(Person person)
    {
        _context.Persons.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }
}