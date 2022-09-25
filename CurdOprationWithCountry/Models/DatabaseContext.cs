using Microsoft.EntityFrameworkCore;

namespace CurdOprationWithCountry.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }   
    }
}
