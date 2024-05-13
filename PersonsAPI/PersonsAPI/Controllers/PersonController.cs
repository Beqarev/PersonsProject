using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PersonsAPI.Interfaces;
using PersonsAPI.Models;
using PersonsAPI.Service;

namespace PersonsAPI.Controllers;
[ApiController]
[Route("api/person")]
public class PersonController : Controller
{
    private readonly IPersonRepository _personRepository;
    private readonly IHubContext<PersonHub> _hubContext;

    public PersonController(IPersonRepository personRepository, IHubContext<PersonHub> hubContext)
    {
        _personRepository = personRepository;
        _hubContext = hubContext;
    }


    [HttpGet]
    public async Task<ActionResult<Person>> GetAll()
    {
        return Ok(await _personRepository.GetPersons());
    }

    [HttpPost]
    public async Task<ActionResult<Person>> AddPerson([FromBody] Person person)
    {
        var result = await _personRepository.AddPerson(person);
        await _hubContext.Clients.All.SendAsync("PersonUpdated!", person);
        return Ok(result);
    }
}