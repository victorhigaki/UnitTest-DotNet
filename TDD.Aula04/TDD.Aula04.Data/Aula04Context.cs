using Microsoft.EntityFrameworkCore;
using TDD.Aula04.Domain.Entities;

namespace TDD.Aula04.Data
{
    public class Aula04Context : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public Aula04Context()
        {
            
        }

        public Aula04Context(DbContextOptions<Aula04Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432/Database=employee_sample;" +
                "User Id=root;" +
                "Password=root;");
    }
}
