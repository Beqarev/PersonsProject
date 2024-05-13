using Microsoft.AspNetCore.SignalR;
using PersonsAPI.Models;

namespace PersonsAPI.Service;

public class PersonHub : Hub
{
    public async Task BroadcastPersonData(Person person)
    {
        await Clients.All.SendAsync("PersonUpdated!", person);
    }
}