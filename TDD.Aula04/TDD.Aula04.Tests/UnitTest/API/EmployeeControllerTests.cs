using TDD.Aula04.API.Controllers;
using TDD.Aula04.Tests.Helpers.Fixtures;

namespace TDD.Aula04.Tests.UnitTest.API
{
    public class EmployeeControllerTests : IClassFixture<DatabaseFixture>
    {
        public DatabaseFixture Fixture { get; set; }
        public EmployeeControllerTests(DatabaseFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void GetEmployee_ReturnEmployee_Success()
        {
            //Arrange
            using var context = Fixture.CreateContext();
            var controller = new EmployeeController(context);
            var nameEmployee = "Almiro";

            //Act
            var result = controller.GetEmployee(nameEmployee).Value;

            //Assert
            Assert.Equal(nameEmployee, result.name);
        }

        [Fact]
        public void AddEmployee()
        {
            //Arrange
            using var context = Fixture.CreateContext();
            context.Database.BeginTransaction();
            var controller = new EmployeeController(context);

            //Act
            var result = controller.AddEmployee("Beltrano", 75, "");
            context.ChangeTracker.Clear();

            var employee = context.Employees.Single(b => b.name == "Beltrano");

            //Assert
            Assert.Equal(75, employee.age);
        }
    }
}
