using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers.Db;

namespace WebApplication1.Data
{
    public class DbContact : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OplataTrudadb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FormOfRemuneration> FormOfRemuneration { get; set; }
        public DbSet<WorkInformation> WorkInformation { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
