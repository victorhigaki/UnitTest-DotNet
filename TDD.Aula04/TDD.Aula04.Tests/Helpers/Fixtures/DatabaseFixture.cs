using Microsoft.EntityFrameworkCore;
using TDD.Aula04.Data;
using TDD.Aula04.Domain.Entities;

namespace TDD.Aula04.Tests.Helpers.Fixtures
{
    public class DatabaseFixture
    {
        private const string _connectionString = @"Server=localhost;" +
            "Port=5432;Database=employee_sample;" +
            "User Id=root" +
            "Password=root;";

        private static object _lock = new object();
        private static bool _databaseInitialze ;

        public DatabaseFixture() { 
            lock(_lock)
            {
                if (!_databaseInitialze) 
                {
                    using var context = CreateContext();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    context.AddRange(
                        new Employee("Almiro", 70, ""),
                        new Employee("Fulano", 10, "")
                    );
                    context.SaveChanges();
                }
            }
        }

        public Aula04Context CreateContext()
        {
            return new Aula04Context(new DbContextOptionsBuilder<Aula04Context>().UseNpgsql(_connectionString).Options);
        }
    }
}