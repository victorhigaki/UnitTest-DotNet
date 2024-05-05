using Microsoft.AspNetCore.Mvc;
using TDD.Aula04.Data;
using TDD.Aula04.Domain.Entities;

namespace TDD.Aula04.API.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly Aula04Context _context;

        public EmployeeController(Aula04Context context) => _context = context;

        [HttpGet]
        public ActionResult<Employee> GetEmployee(string name)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.name == name);
            return employee is null ? NotFound() : employee;
        }

        [HttpPost]
        public ActionResult AddEmployee(string name, int age, string photo)
        {

            _context.Employees.Add(new Employee(name, age, photo));
            _context.SaveChanges();
            return Ok();
        }
    }
}
