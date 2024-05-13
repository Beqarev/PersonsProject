using Microsoft.EntityFrameworkCore;
using PersonsAPI.Models;

namespace PersonsAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Person> Persons { get; set; }
}