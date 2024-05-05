namespace TDD.Aula04.Domain.Entities
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string photo { get; set; }

        public Employee(string name, int age, string photo)
        {
            name = name;
            this.age = age;
            this.photo = photo;
        }
    }
}
